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
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(MyContext db):base(db)
        {
            
        }

        public async Task<bool> AddUserProfileAsync(UserProfile userProfile)
        {
            try
            {
                await AddAsync(userProfile);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
