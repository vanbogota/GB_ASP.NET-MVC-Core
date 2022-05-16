using FinalProject.Interfaces;
using FinalProject.Jobs;
using FinalProject.Services;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddSingleton<ISendMessageService,SendMessageService>();
builder.Services.AddSingleton<MessageGateway>();
builder.Services.AddSingleton(new MailGatewayOptions()
{
    Password = "****",
    SenderName = "server@mail.ru",
    SMTPServer = "smtp.mail.ru",
    Sender = "server",
    Port = 465
});
builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddSingleton<SendMessageJob>();
builder.Services.AddSingleton(new JobSchedule(
    jobType: typeof(SendMessageJob),
    cronExpression: "0 42 10 ? *WED")); //every wenthday at 10:42

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
