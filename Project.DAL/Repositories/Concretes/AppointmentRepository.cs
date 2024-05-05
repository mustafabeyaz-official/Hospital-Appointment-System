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
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(MyContext db):base(db)
        {
            
        }

        public async Task<bool> AddAppointmentAsync(Appointment appointment)
        {
            int id = appointment.ID;
            await this.AddAsync(appointment);
            bool result =  await this.AnyAsync(x => x.ID == id);
            if(result)
            {
                return true;
            }
            return false;
        }
    }
}
