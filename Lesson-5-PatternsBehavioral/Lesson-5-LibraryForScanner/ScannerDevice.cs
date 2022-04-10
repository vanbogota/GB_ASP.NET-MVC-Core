using Lesson_5_PatternsBehavioral;
using System.Text;

namespace Lesson_5_LibraryForScanner
{
    public class ScannerDevice 
    {
        private IScannerDevice _scannerDevice;
        private IScannerOutputStrategy _outputStrategy;
                        
        public ScannerDevice(
            IScannerDevice scannerDevice, 
            IScannerOutputStrategy scannerOutputStrategy)
        {
            _scannerDevice = scannerDevice;            
            _outputStrategy = scannerOutputStrategy;            
        }

        public void Execute(string outputFileName)
        {
            if (string.IsNullOrEmpty(outputFileName))
            {
                throw new ArgumentNullException($"OutputFileName can't be null");
            }

            _outputStrategy.ScanAndSave(_scannerDevice, outputFileName);

            using (FileStream fs = new FileStream("LogFile.txt", FileMode.OpenOrCreate))
            {
                byte[] info = new UTF8Encoding(true).GetBytes($"Loaded processor {_scannerDevice.ProcessorLoadPersent}%\nLoaded memory {_scannerDevice.MemoryLoadBytes} bytes");
                fs.Write(info, 0, info.Length);
            }
        }      
    }
}