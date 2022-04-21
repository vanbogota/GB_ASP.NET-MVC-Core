namespace DiskTemplateEngine
{
    public sealed class DiskInfo
    {
        public string DiskName { get; set; } = null!;

        public List<Disk>? DiskMetrics { get; set; }
    }
}
