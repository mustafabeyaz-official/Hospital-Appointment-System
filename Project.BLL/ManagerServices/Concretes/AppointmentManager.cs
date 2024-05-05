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
    public class AppointmentManager : BaseManager<Appointment>, IAppointmentManager
    {
        IAppointmentRepository _repository;
        public AppointmentManager(IAppointmentRepository repositiory):base(repositiory)
        {
            _repository = repositiory;  
        }

        public async Task<bool> CreateAppointmentAsync(Appointment appointment)
        {
            return await _repository.AddAppointmentAsync(appointment);
        }
    }
}
