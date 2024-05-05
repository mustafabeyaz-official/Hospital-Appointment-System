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
    public class HospitalManager : BaseManager<Hospital>, IHospitalManager
    {
        IHospitalRepository _repository;
        public HospitalManager(IHospitalRepository repository):base(repository)
        {
            _repository = repository;   
        }

        public async Task<bool> CreateHospitalAsync(Hospital hospital)
        {
            return await _repository.AddHospitalAsync(hospital);
        }
    }
}
