namespace Project.WebAPI.Models.Appointments.RequestModels
{
    public class CreateAppointmentRequestModel
    {
        //parameter properties
        //don't add UserID, this is appointment creation, not taking appointment
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
