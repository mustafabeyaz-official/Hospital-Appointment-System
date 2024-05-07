using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.Hospitals.RequestModels;
using Project.WebAPI.Models.Hospitals.ResponseModels;
using System.Collections.Generic;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        IHospitalManager _hospitalManager;
        IClinicListManager _clinicListManager;
        IClinicManager _clinicManager;
        public HospitalController(IHospitalManager hospitalManager, IClinicListManager clinicListManager, IClinicManager clinicManager)
        {
            _hospitalManager = hospitalManager;
            _clinicManager = clinicManager;
            _clinicListManager = clinicListManager;
        }

        //listing hospitals with extra properties
        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            List<HospitalResponseModel> hospitals = _hospitalManager.Select(x => new HospitalResponseModel
            {
                ID = x.ID,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status,
                HospitalName = x.HospitalName,
                Address = x.Address,
            }).ToList();

            //extra properties implementation
            foreach(var hospital in hospitals)
            {
                var clinicIDS = _clinicListManager
                    .Where(cl => cl.HospitalID == hospital.ID)
                    .Select(cl => cl.ClinicID).ToList();
                hospital.Clinics = _clinicManager
                    .Where(c => clinicIDS.Contains(c.ID))
                    .Select(c => c.ClinicName).ToList();
            }

            return Ok(hospitals);
        }

        //recording hospital record
        [HttpPost]
        public async Task<IActionResult> CreateHospital(CreateHospitalRequestModel model)
        {
            Hospital hospital = new()
            {
                HospitalName = model.HospitalName,
                Address = model.Address
            };
            bool result = await _hospitalManager.CreateHospitalAsync(hospital);

            if(result)
            {
                return Ok("hospital successfully added");
            }
            return BadRequest("an error occured");
        }
    }
}
