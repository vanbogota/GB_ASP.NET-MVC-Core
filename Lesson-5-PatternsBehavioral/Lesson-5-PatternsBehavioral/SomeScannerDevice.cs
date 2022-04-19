using System.Diagnostics;

namespace Lesson_6_ScannerAutofac;

public class SomeScannerDevice : ScannerDevice
{
    private PerformanceCounter? _cpucounter;

    private PerformanceCounter? _memcounter;

    private string _inputFileName;

    public SomeScannerDevice(string inputFileName)
    {
        if (string.IsNullOrEmpty(inputFileName))
        {
            throw new ArgumentNullException("Input file name can't be null");
        }
        _inputFileName = inputFileName;
        _cpucounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        _memcounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
    }
    public override int ProcessorLoadPersent { get; set; }
    public override int MemoryLoadBytes { get; set; }
    
    public override Stream Scan()
    {
        using (FileStream streamWriter = new FileStream(_inputFileName, FileMode.Create))
        {
            ProcessorLoadPersent = (int)_cpucounter.NextValue();
            MemoryLoadBytes = (int)_memcounter.NextValue();

            return streamWriter;
        };        
    }    
}