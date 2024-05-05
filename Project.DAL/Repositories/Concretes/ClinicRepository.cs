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
    public class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(MyContext db):base(db)
        {
            
        }

        public async Task<bool> AddClinicAsync(Clinic clinic)
        {
            try
            {
                await AddAsync(clinic);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
