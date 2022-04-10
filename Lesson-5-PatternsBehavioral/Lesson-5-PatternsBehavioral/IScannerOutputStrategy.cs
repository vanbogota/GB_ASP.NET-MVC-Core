using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_PatternsBehavioral
{
    public interface IScannerOutputStrategy
    {
        void ScanAndSave(IScannerDevice scanerDevice, string output);
    }
}
