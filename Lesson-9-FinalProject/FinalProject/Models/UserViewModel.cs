using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Models
{
    public class UserViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;        
    }
}
