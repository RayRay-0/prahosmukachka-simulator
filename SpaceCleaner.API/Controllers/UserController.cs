using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpaceCleaner.API.Data.Entities;

namespace SpaceCleaner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("CreateRoles")]
        public async Task<string> CreateRoles()
        {
            var roles = new List<IdentityRole>() {
                new IdentityRole() { Name = "ADMIN" },
                new IdentityRole() { Name = "USER" }
            };

            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }
            return "Roles created.";
            
        }

        [HttpGet("CreateAdmin")]
        public async Task<string> CreateAdmin()
        {
            var user = new User()
            {
                Email = "aeg@gmail.com",
                UserName = "aeg@gmail.com"
            };
            await _userManager.CreateAsync(user, "Pass#123");

            await _userManager.AddToRoleAsync(user, "ADMIN");
            return "Created user.";
        }
    }
}
