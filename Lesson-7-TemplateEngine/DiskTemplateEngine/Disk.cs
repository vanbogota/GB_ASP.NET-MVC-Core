namespace DiskTemplateEngine
{
    public sealed class Disk
    {
        public string DiskName { get; set; } = null!;
        public DateTime DateOfMetric { get; set; }
        public float Memory { get; set; }
    }
}
