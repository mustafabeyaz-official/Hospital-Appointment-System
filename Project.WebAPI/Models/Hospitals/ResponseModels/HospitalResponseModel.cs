using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;

namespace Project.WebAPI.Models.Hospitals.ResponseModels
{
    public class HospitalResponseModel
    {
        //derived properties
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //main properties
        public string HospitalName { get; set; }
        public string Address { get; set; }

        //extra properties
        public List<string> Clinics { get; set; }
        public List<string> Doctors { get; set; }
    }
}
