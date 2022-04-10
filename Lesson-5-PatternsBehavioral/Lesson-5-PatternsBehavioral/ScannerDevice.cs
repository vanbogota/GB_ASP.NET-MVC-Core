using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_PatternsBehavioral
{
    public class ScannerDevice : IScannerDevice
    {
        public int ProcessorLoadPersent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MemoryLoadBytes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Stream Scan(string inputFilePath)
        {
            throw new NotImplementedException();
        }                
    }
}
