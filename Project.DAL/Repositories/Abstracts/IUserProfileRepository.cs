using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        public Task<bool> AddUserProfileAsync(UserProfile userProfile);
    }
}
