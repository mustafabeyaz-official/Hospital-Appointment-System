using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Clinics.RequestModels;
using Project.WebAPI.Models.Clinics.ResponseModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        IClinicManager _clinicManager;
        IClinicListManager _clinicListManager;
        IHospitalManager _hospitalManager;
        IDoctorManager _doctorManager;
        public ClinicController(IClinicManager clinicManager, IClinicListManager clinicListManager, IHospitalManager hospitalManager, IDoctorManager doctorManager)
        {
            _clinicManager = clinicManager;
            _clinicListManager = clinicListManager;
            _hospitalManager = hospitalManager;
            _doctorManager = doctorManager;
        }

        //get clinic records with extra properties
        [HttpGet]
        public async Task<IActionResult> GetAdminClinics()
        {
             List<ClinicResponseModel> data = _clinicManager.Select(c => new ClinicResponseModel
             {
                ID = c.ID,
                CreatedDate = c.CreatedDate,
                ModifiedDate = c.ModifiedDate,
                DeletedDate = c.DeletedDate,
                Status = c.Status,
                ClinicName = c.ClinicName,
                Description = c.Description
             }).ToList();

            //implementation extra properties
            foreach(var clinic in data)
            {
                clinic.HospitalID = _clinicListManager
                    .Where(cl => cl.ClinicID == clinic.ID)
                    .Select(cl => cl.HospitalID)
                    .FirstOrDefault();
                clinic.HospitalName = _hospitalManager
                    .Where(h => h.ID == clinic.HospitalID)
                    .Select(h => h.HospitalName)
                    .FirstOrDefault()!;
                clinic.Doctors = _doctorManager
                    .Where(d => d.ClinicID == clinic.ID)
                    .Select(d => d.FirstName).ToList();
            }

            return Ok(data);
        }

        //recording clinics and ClinicList data's to database
        [HttpPost]
        public async Task<IActionResult> CreateClinic(CreateClinicRequestModel model)
        {
            Clinic clinic = new()
            {
                ClinicName = model.ClinickName,
                Description = model.Description,
            };
            bool result = await _clinicManager.CreateClinicAsync(clinic);

            ClinicList clinicList = new()
            {
                HospitalID = model.HospitalID,
                ClinicID = clinic.ID
            };
            bool result2 = await _clinicListManager.CreateClinicToListAsync(clinicList);

            if (result & result2)
            {
                return Ok("clinic successfully added");
            }
            return BadRequest("an error occured");
        }
    }
}
