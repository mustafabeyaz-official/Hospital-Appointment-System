using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IUserProfileManager : IManager<UserProfile>
    {
        public Task<bool> CreateUserProfileAsync(UserProfile profile);
    }
}
