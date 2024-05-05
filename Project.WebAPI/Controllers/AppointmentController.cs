using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Appointments.RequestModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        IAppointmentManager _appointmentManager;
        IDoctorManager _doctorManager;
        IUserManager _userManager;
        IUserProfileManager _userProfileManager;
        public AppointmentController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentRequestModel model)
        {
            Appointment appointment = new()
            {
                DoctorID = _doctorManager.Where(x => string.Concat(x.FirstName, " ", x.LastName)
                .ToLower() == model.DoctorFullName.ToLower()).Select(x => x.ID).FirstOrDefault(),
                
                UserID = _userProfileManager.Where(x => string.Concat(x.FirstName," ", x.LastName)
                .ToLower() == model.PatientFullName.ToLower()).Select(x => x.ID).FirstOrDefault(),
                CreatedDate = model.AppointmentDate
            };

            string result = _appointmentManager.Add(appointment);
            return Ok(result);
        }
    }
}
