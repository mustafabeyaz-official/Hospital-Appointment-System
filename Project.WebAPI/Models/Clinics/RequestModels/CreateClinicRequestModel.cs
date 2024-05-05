namespace Project.WebAPI.Models.Clinics.RequestModels
{
    public class CreateClinicRequestModel
    {
        public string ClinickName { get; set; }
        public string Description { get; set; }
        public int HospitalID { get; set; }
    }
}
