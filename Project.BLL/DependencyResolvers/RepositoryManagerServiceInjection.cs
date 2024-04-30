using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DependencyResolvers
{
    public static class RepositoryManagerServiceInjection
    {
        public static IServiceCollection AddRepositoryManagerServices(this IServiceCollection services)
        {
            //main interfaceses, classes
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            //repositories
            services.AddScoped<IAppointmentRepositiory, AppointmentRepository>();
            services.AddScoped<IClinicLIstRepository, ClinicListRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            //managers

            return services;
        }
    }
}
