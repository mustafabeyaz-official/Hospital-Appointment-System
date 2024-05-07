using Project.ENTITIES.Enums;

namespace Project.WebAPI.Models.Appointments.ResponseModels
{
    public class AppointmentResponseModel
    {
        //derived properties
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //extra properties
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int? UserID { get; set; }
        public int? UserName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ClinicID { get; set; }
        public string ClinicName { get; set;}
        public int HospitalID { get; set; }
        public string HospitalName { get;set; }
    }
}
