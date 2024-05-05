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
    public class ClinicManager : BaseManager<Clinic>, IClinicManager
    {
        IClinicRepository _repository;
        public ClinicManager(IClinicRepository repository):base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateClinicAsync(Clinic clinic)
        {
            return await _repository.AddClinicAsync(clinic);
        }
    }
}
