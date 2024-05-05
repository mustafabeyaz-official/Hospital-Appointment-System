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
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(MyContext db):base(db)
        {
            
        }

        public async Task<bool> AddHospitalAsync(Hospital hospital)
        {
            try
            {
                await AddAsync(hospital);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
