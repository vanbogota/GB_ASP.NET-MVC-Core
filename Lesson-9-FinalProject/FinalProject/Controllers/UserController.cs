using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userRepository.Add(user);
            _logger.LogInformation("User added");
            return RedirectToAction("Index");
        }
                
        public IActionResult Index()
        {
            return View();
        }
    }
}
