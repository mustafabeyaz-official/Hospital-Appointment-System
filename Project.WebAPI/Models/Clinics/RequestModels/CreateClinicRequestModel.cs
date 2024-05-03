using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Project.BLL.ManagerServices.Abstracts;

namespace Project.WebAPI.Models.Clinics.RequestModels
{
    public class CreateClinicRequestModel
    {
        public string ClinicName { get; set; }
        public string ClinicDescription { get; set; }
        public int HospitalId { get; set; }
    }
}
