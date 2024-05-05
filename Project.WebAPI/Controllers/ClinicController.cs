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
            _clinicManager = clinicManager;
            _clinicListManager = clinicListManager;
        }

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
