namespace Project.WebAPI.Models.Users.RequestModels
{
    public class UserRegisterRequestModel
    {
        public string UserName { get; set; }

        //firstname and lastname properties for creating user profile
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set;}
    }
}
