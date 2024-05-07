using Project.ENTITIES.Enums;

namespace Project.WebAPI.Models.Clinics.ResponseModels
{
    public class ClinicResponseModel
    {
        //derived properties
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //main properties
        public string ClinicName { get; set; }
        public string Description { get; set; }

        //extra properties
        public int HospitalID { get; set; }
        public string HospitalName { get; set;}
        public List<string> Doctors { get; set; }
    }
}
