using FinalProject.Jobs;
using FinalProject.Repositories;
using FinalProject.Services;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddSingleton<ISendMessageService,SendMessageService>();
builder.Services.AddSingleton<IUserRepository, UserService>();
builder.Services.AddSingleton<MessageGateway>();
builder.Services.AddSingleton(new MailGatewayOptions()
{
    Password = "****",
    SenderName = "server@mail.ru",
    SMTPServer = "smtp.mail.ru",
    Sender = "Report server",
    Port = 465
});
builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddSingleton<SendMessageJob>();
builder.Services.AddSingleton(new JobSchedule(
    jobType: typeof(SendMessageJob),
    cronExpression: "0 42 10 ? * WED")); //every wenthday at 10:42

var configure = builder.Configuration;
string conString = configure["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(conString), ServiceLifetime.Singleton);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
