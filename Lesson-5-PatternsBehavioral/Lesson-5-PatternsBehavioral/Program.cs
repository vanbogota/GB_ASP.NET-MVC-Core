using Autofac;

namespace Lesson_6_ScannerAutofac;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        
        builder.RegisterType<SomeScannerDevice>().As<IScannerDevice>();

        builder.RegisterAdapter<IScannerDevice, ScannerDeviceContext>(adapter => new ScannerDeviceContext(adapter));

        IContainer container = builder.Build();

        SomeScannerDevice device = container.Resolve<SomeScannerDevice>();

        ScannerDeviceContext scannerDevice = container.Resolve<ScannerDeviceContext>();
                
    }
}
