using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Doctors.RequestModels;
using Project.WebAPI.Models.Doctors.ResponseModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        IDoctorManager _doctormanager;
        IClinicManager _clinicmanager;
        IClinicListManager _cliniclistmanager;
        IHospitalManager _hospitalmanager;
        public DoctorController(IDoctorManager doctorManager, IClinicManager clinicManager, IClinicListManager cliniclistmanager, IHospitalManager hospitalmanager)
        {
            _clinicmanager = clinicManager;
            _doctormanager = doctorManager;
            _cliniclistmanager = cliniclistmanager;
            _hospitalmanager = hospitalmanager;
        }

        //listing doctor records with extra properties
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            List<DoctorResponseModel> doctors = _doctormanager.Select(d => new DoctorResponseModel
            {
                ID = d.ID,
                CreatedDate = d.CreatedDate,
                ModifiedDate = d.ModifiedDate,
                DeletedDate = d.DeletedDate,
                Status = d.Status,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Title = d.Title,
                ClinicId = d.ClinicID,
            }).ToList();

            //implementation extra properties
            foreach(var doctor in doctors)
            {
                var clinicIDS = _clinicmanager
                    .Where(cl => cl.ID == doctor.ClinicId)
                    .Select(cl => cl.ID).ToList();
                doctor.ClinicName = _clinicmanager
                    .Where(c => clinicIDS.Contains(c.ID))
                    .Select(c => c.ClinicName)
                    .FirstOrDefault()!;

                var hospitalIDS = _cliniclistmanager
                    .Where(cl => clinicIDS.Contains(cl.ClinicID))
                    .Select(cl => cl.HospitalID).ToList();
                doctor.HospitalID = hospitalIDS.FirstOrDefault();
                doctor.HospitalName = _hospitalmanager
                    .Where(h => h.ID == doctor.HospitalID)
                    .Select(h => h.HospitalName)
                    .FirstOrDefault()!;
            }

            return Ok(doctors);
        }

        //recording doctor records
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorRequestModel model)
        {
            Doctor doctor = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                ClinicID = model.ClinicID,
            };

            bool result = await _doctormanager.CreateDoctorAsync(doctor);
            if (result)
            {
                return Ok("doctor added");
            }
            return BadRequest("an error occured");
        }
    }
}
