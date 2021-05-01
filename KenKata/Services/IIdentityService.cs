using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Services
{
    public interface IIdentityService
    {
        Task CreateRootAccountAsync();

        Task CreateNewRole(string roleName);
        
        Task AddUserToRole(IdentityUser user, string roleName);

        IEnumerable<IdentityUser> GetAllUsers();

        IEnumerable<IdentityRole> GetAllRoles();
    }
}
