using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.Authentication;
using Wareship.Model.Indonesia;
using Wareship.ViewModel.Global;
using Wareship.ViewModel.Indonesia;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndonesiaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IndonesiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("province")]
        public async Task<ActionResult<IEnumerable<Provinces>>> GetAllProvince()
        {
            var stat = new Status();
            var resp = new ProvinceResponse();
            var result = new ProvinceListResponse
            {
                Provinces = await _context.Provinces.OrderBy(x => x.Name).ToListAsync()
            };

            stat.ResponseCode = StatusCodes.Status200OK;
            stat.ResponseMessage = "Success";
            resp.Status = stat;
            resp.Result = result;
            
            return Ok(resp);
        }

        [HttpGet]
        [Route("city/{ProvinceId}")]
        public async Task<ActionResult<IEnumerable<Regencies>>> GetAllCity(string ProvinceId)
        {
            var stat = new Status();
            var resp = new CityResponse();
            var result = new CityListResponse
            {
                Cities = await _context.Regencies.Where(x => x.ProvinceId == ProvinceId).OrderBy(x => x.Name).ToListAsync()
            };

            stat.ResponseCode = StatusCodes.Status200OK;
            stat.ResponseMessage = "Success";
            resp.Status = stat;
            resp.Result = result;

            return Ok(resp);
        }

        [HttpGet]
        [Route("subdistrict/{CityId}")]
        public async Task<ActionResult<IEnumerable<SubDistricts>>> GetAllSubdistrict(string CityId)
        {
            var stat = new Status();
            var resp = new SubDistrictResponse();
            var result = new SubDistrictListResponse
            {
                SubDistricts = await _context.SubDistricts.Where(x => x.RegencyId == CityId).OrderBy(x => x.Name).ToListAsync()
            };

            stat.ResponseCode = StatusCodes.Status200OK;
            stat.ResponseMessage = "Success";
            resp.Status = stat;
            resp.Result = result;

            return Ok(resp);
        }
    }


}
