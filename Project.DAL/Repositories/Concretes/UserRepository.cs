using Microsoft.AspNetCore.Identity;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        UserManager<User> _userManager;
        public UserRepository(MyContext db, UserManager<User> userManager):base(db)
        {
            _userManager = userManager;
        }
        public async Task<bool> AddUser(User user)
        {
            IdentityResult result = await _userManager.CreateAsync(user, user.PasswordHash!);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
