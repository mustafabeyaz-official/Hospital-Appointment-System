namespace Project.WebAPI.Models.Appointments.RequestModels
{
    public class CreateAppointmentRequestModel
    {
        public string DoctorFullName { get; set; }
        public string PatientFullName { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
