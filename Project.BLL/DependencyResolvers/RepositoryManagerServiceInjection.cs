using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
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
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));

            //repositories
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IClinicLIstRepository, ClinicListRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            //managers
            services.AddScoped<IAppointmentManager, AppointmentManager>();
            services.AddScoped<IClinicListManager, ClinicListManager>();
            services.AddScoped<IClinicManager, ClinicManager>();
            services.AddScoped<IDoctorManager, DoctorManager>();
            services.AddScoped<IHospitalManager, HospitalManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserProfileManager, UserProfileManager>();

            return services;
        }
    }
}
