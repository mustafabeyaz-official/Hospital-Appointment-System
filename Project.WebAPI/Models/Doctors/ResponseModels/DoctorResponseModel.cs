using Project.ENTITIES.Enums;

namespace Project.WebAPI.Models.Doctors.ResponseModels
{
    public class DoctorResponseModel
    {
        //derived properties
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //main properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int ClinicId { get; set; }

        //extra properties
        public string ClinicName { get; set; }
        public int HospitalID { get; set; }
        public string HospitalName { get;set; }
    }
}
