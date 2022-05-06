using FinalProject.Interfaces;

namespace FinalProject.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsDeleted { get; set; }

    }
}