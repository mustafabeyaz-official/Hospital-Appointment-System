using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Clinics.RequestModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        IClinicManager _clinicManager;
        IClinicListManager _clinicListManager;
        public ClinicController(IClinicManager clinicManager, IClinicListManager clinicListManager)
        {
            _clinicListManager = clinicListManager;
            _clinicManager = clinicManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClinic(CreateClinicRequestModel model)
        {
            Clinic clinic = new()
            {
                ClinicName = model.ClinicName,
                Description = model.ClinicDescription
            };
            await _clinicManager.AddAsync(clinic);
            ClinicList clinicList = new()
            {
                HospitalID = model.HospitalId,
                ClinicID = clinic.ID
            };
            await _clinicListManager.AddAsync(clinicList);
            return Ok("success");
        }
    }
}
