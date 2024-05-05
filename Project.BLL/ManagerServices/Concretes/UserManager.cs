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
    public class UserManager : BaseManager<User>, IUserManager
    {
        IUserRepository _repository;
        public UserManager(IUserRepository repository):base(repository)
        {
            _repository = repository;   
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            return await _repository.AddUserAsync(user);
        }
    }
}
