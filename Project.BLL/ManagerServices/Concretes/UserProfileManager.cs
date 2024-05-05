using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class UserProfileManager : BaseManager<UserProfile>, IUserProfileManager
    {
        IUserProfileRepository _repository;
        public UserProfileManager(IUserProfileRepository repository):base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateUserProfileAsync(UserProfile profile)
        {
            return await _repository.AddUserProfileAsync(profile);
        }
    }
}
