using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Government.Entities;  // Assuming ApplicationUser is in this namespace

namespace Government.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminRegisterController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AuthController> _logger;

        public AdminRegisterController(UserManager<AppUser> userManager, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the email already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already in use.");
            }

            // Check if the username already exists
            var existingUsername = await _userManager.FindByNameAsync(model.UserName);
            if (existingUsername != null)
            {
                return BadRequest("Username is already in use.");
            }

            // Create a new ApplicationUser object
            var admin = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                NormalizedEmail = model.Email.ToUpper(),
                NormalizedUserName = model.UserName.ToUpper(),
                EmailConfirmed = false,  // Default to false
                PhoneNumberConfirmed = false,  // Default to false
                TwoFactorEnabled = false,  // Default to false
                LockoutEnabled = false,  // Default to false
                AccessFailedCount = 0 // Default to 0
            };

            // Hash the password
            var result = await _userManager.CreateAsync(admin, model.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation($"User {admin.UserName} created successfully.");
                return Ok("User registered successfully.");
            }

            // If there are errors, return them
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }
    }


    // Register model (you can extend this with more properties if needed)
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
