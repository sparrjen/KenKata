using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Services
{

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task AddUserToRole(IdentityUser user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CreateNewRole(string roleName)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

      

        public async Task CreateRootAccountAsync()
        {
            if (!_userManager.Users.Any())
            {
                var user = new IdentityUser()
                {
                    UserName = "admin@domain.com",
                    Email = "admin@domain.com"
                };
                var result = await _userManager.CreateAsync(user, "BytMig123!");

                if (result.Succeeded)
                {
                    if (!_roleManager.Roles.Any())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        await _roleManager.CreateAsync(new IdentityRole("StoreCustomer"));

                    }

                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                }
            }
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles;
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users;
        }
    }
}
