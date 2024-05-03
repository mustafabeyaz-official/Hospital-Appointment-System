using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Doctors.RequsetModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        IDoctorManager _doctorManager;
        public DoctorController(IDoctorManager doctorManager)
        {
            _doctorManager = doctorManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorRequestModel model)
        {
            Doctor doctor = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                ClinicID = model.ClinicId
            };
            
            string result = _doctorManager.Add(doctor);
            return Ok(result);
        }
    }
}
