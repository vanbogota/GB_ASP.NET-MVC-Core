namespace Lesson_6_ScannerAutofac
{
    public class ScannerDeviceContext
    {
        private IScannerDevice _scannerDevice;
        private IScannerOutputStrategy? _outputStrategy;

        public ScannerDeviceContext(IScannerDevice scannerDevice)
        {
            _scannerDevice = scannerDevice;            
        }

        public void SetScannerOutputStrategy(IScannerOutputStrategy scannerOutputStrategy)
        {
            _outputStrategy = scannerOutputStrategy;
        }

        public void Execute(string outputFileName)
        {
            if (string.IsNullOrEmpty(outputFileName))
            {
                throw new ArgumentNullException("OutputFileName can't be null");
            }
            if(_outputStrategy == null)
            {
                throw new ArgumentNullException("OutputSrategy can't be null");
            }
            if(_scannerDevice == null)
            {
                throw new ArgumentNullException("ScannerDevice can't be null");
            }
            
            _outputStrategy.ScanAndSave(_scannerDevice, outputFileName);

            string[] info = {
                $"Loaded processor {_scannerDevice.ProcessorLoadPersent}%",
                $"Loaded memory {_scannerDevice.MemoryLoadBytes} bytes"};

            File.AppendAllLines("LogFile.txt", info);
        }
    }
}