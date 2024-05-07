namespace Project.WebAPI.Models.Doctors.RequestModels
{
    public class CreateDoctorRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int ClinicID { get; set; }
    }
}
