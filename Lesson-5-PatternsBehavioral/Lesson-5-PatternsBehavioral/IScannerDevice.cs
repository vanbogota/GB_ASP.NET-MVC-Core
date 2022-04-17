using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
namespace Lesson_6_ScannerAutofac
{
    public interface IScannerDevice
    {
        int ProcessorLoadPersent { get; set; }
        int MemoryLoadBytes { get; set; }
        Stream Scan();        
    }
}
