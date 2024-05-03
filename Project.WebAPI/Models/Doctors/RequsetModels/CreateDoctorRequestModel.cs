namespace Project.WebAPI.Models.Doctors.RequsetModels
{
    public class CreateDoctorRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int ClinicId { get; set; }
    }
}
