using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DependencyResolvers
{
    public static class DBContextServiceInjection
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();

            services.AddDbContextPool<MyContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("MyConnection")));
            return services;
        }
    }
}
