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
    public class ClinicListRepository : BaseRepository<ClinicList>, IClinicLIstRepository
    {
        public ClinicListRepository(MyContext db):base(db)
        {
            
        }

        public async Task<bool> AddClinicToListAsync(ClinicList clinicList)
        {
            try
            {
                await AddAsync(clinicList);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
