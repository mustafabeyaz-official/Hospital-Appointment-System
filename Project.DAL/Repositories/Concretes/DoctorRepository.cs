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
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(MyContext db):base(db)
        {
            
        }

        public async Task<bool> AddDoctorAsync(Doctor doctor)
        {
            try
            {
                await AddAsync(doctor);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
