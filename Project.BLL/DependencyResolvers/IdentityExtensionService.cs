using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DependencyResolvers
{
    public static class IdentityExtensionService
    {
        public static IServiceCollection AddIdentityExtension(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(x =>
            {
                x.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                x.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<MyContext>();

            return services;
        }
    }
}
