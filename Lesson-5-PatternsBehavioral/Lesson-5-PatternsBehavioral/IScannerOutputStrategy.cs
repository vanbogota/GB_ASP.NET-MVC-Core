namespace Lesson_6_ScannerAutofac
{
    public interface IScannerOutputStrategy
    {
        void ScanAndSave(IScannerDevice scanerDevice, string output);
    }
}
