using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Appointments.RequestModels;
using Project.WebAPI.Models.Appointments.ResponseModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        IAppointmentManager _appointmentManager;
        IDoctorManager _doctorManager;
        IClinicManager _clinicManager;
        IClinicListManager _clinicListManager;
        IHospitalManager _hospitalManager;
        public AppointmentController(IAppointmentManager appointmentManager, IDoctorManager doctorManager, IClinicManager clinicManager, IClinicListManager clinicListManager, IHospitalManager hospitalManager)
        {
            _appointmentManager = appointmentManager;
            _doctorManager = doctorManager;
            _clinicManager = clinicManager;
            _clinicListManager = clinicListManager;
            _hospitalManager = hospitalManager;
        }

        //get appointments from database with extra properties
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            List<AppointmentResponseModel> appointments = _appointmentManager.Select(a =>  new AppointmentResponseModel
            {
                ID = a.ID,
                CreatedDate = a.CreatedDate,
                ModifiedDate = a.ModifiedDate,
                DeletedDate = a.DeletedDate,
                Status = a.Status,
                DoctorID = a.DoctorID,
                UserID = a.UserID,
                AppointmentDate = a.AppointmentDate,
            }).ToList();

            //implementation extra properties
            foreach(var appointment in appointments)
            {
                appointment.DoctorID = _doctorManager
                    .Where(d => d.ID == appointment.DoctorID)
                    .Select(d => d.ID)
                    .FirstOrDefault();
                appointment.DoctorName = _doctorManager
                    .Where(d => d.ID == appointment.DoctorID)
                    .Select(d => string.Concat(d.Title, " ", d.FirstName, " ", d.LastName))
                    .FirstOrDefault()!;
                appointment.ClinicID = _doctorManager
                    .Where(d => d.ID == appointment.DoctorID)
                    .Select(d => d.ClinicID)
                    .FirstOrDefault();
                appointment.ClinicName = _clinicManager
                    .Where(c => c.ID == appointment.ClinicID)
                    .Select(c => c.ClinicName)
                    .FirstOrDefault()!;
                appointment.HospitalID = _clinicListManager
                    .Where(cl => cl.ClinicID == appointment.ClinicID)
                    .Select(cl => cl.HospitalID)
                    .FirstOrDefault();
                appointment.HospitalName = _hospitalManager
                    .Where(h => h.ID ==  appointment.HospitalID)
                    .Select(h => h.HospitalName)
                    .FirstOrDefault()!;
            }

            return Ok(appointments);
        }

        //recording appointment to database
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentRequestModel model)
        {
            Appointment appointment = new()
            {
                DoctorID = model.DoctorID,
                AppointmentDate = model.AppointmentDate,
            };

            bool result = await _appointmentManager.CreateAppointmentAsync(appointment);
            if (result)
            {
                return Ok("appointment created");
            }
            return BadRequest("an error occured");
        }
    }
}
