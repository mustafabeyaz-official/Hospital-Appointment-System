using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Hospitals.RequestModels;
using Project.WebAPI.Models.Hospitals.ResponseModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        IHospitalManager _manager;
        public HospitalController(IHospitalManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHospital(CreateHospitalRequestModel model)
        {
            Hospital hospital = new()
            {
                HospitalName = model.HospitalName,
                Address = model.HospitalAddress
            };

            string result = _manager.Add(hospital);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            List<HospitalResponseModel> hospitals = _manager.Select(x => new HospitalResponseModel
            {
                HospitalName = x.HospitalName,
                Address = x.Address,
            }).ToList();

            return Ok(hospitals);
        }
    }
}