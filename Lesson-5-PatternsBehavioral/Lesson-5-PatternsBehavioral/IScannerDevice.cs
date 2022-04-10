using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson_5_PatternsBehavioral
{
    public interface IScannerDevice
    {
        int ProcessorLoadPersent { get; set; }
        int MemoryLoadBytes { get; set; }
        Stream Scan(string inputFilePath);        
    }
}
