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
    public class DoctorManager : BaseManager<Doctor>, IDoctorManager
    {
        IDoctorRepository _repository;
        public DoctorManager(IDoctorRepository repository):base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateDoctorAsync(Doctor doctor)
        {
            return await _repository.AddDoctorAsync(doctor);
        }
    }
}
