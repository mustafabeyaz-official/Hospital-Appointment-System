namespace Project.WebAPI.Models.Clinics.RequestModels
{
    public class CreateClinicRequestModel
    {
        public string ClinickName { get; set; }
        public string Description { get; set; }
        //hospitalID for recording clinics to conjunction table 'ClinicList'
        public int HospitalID { get; set; }
    }
}
