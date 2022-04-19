using Lesson_6_ScannerAutofac;

namespace Lesson_5_LibraryForScanner
{
    public sealed class PdfScanOutputStrategy : IScannerOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            ScannerDeviceContext sdc = new ScannerDeviceContext(scannerDevice);
            sdc.SetScannerOutputStrategy(this);
            sdc.Execute(outputFileName);
        }
    }
}