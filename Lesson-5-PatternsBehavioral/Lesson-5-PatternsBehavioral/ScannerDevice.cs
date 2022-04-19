namespace Lesson_6_ScannerAutofac
{
    public abstract class ScannerDevice : IScannerDevice
    {
        public abstract int ProcessorLoadPersent { get; set; }
        public abstract int MemoryLoadBytes { get; set; }

        public abstract Stream Scan();        
    }
}
