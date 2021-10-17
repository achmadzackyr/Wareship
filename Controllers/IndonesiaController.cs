using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using Wareship.ViewModel.Global;
using Wareship.ViewModel.Indonesia;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndonesiaController : ControllerBase
    {
        [HttpGet]
        [Route("province")]
        public IActionResult GetAllProvince()
        {
            var stat = new Status();
            var resp = new ProvinceResponse();

            var client = new RestClient("https://dev.farizdotid.com/api/daerahindonesia/provinsi");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if(response.IsSuccessful)
            {
                var orderedProvList = new List<Provinsi>();
                var provList = JsonConvert.DeserializeObject<ProvinceListResponse>(response.Content);
                var result = new ProvinceListResponse();
                
                foreach(var p in provList.Provinsi)
                {
                    orderedProvList.Add(p);
                }
                orderedProvList.Sort(delegate (Provinsi x, Provinsi y) {
                    return x.Nama.CompareTo(y.Nama);
                });

                result.Provinsi = orderedProvList;

                stat.ResponseCode = StatusCodes.Status200OK;
                stat.ResponseMessage = "Success";
                resp.Status = stat;
                resp.Result = result;
                //resp.Result = provList;
            }
            
            return Ok(resp);
        }

        [HttpGet]
        [Route("city/{id_provinsi}")]
        public IActionResult GetAllCity(int id_provinsi)
        {
            var stat = new Status();
            var resp = new CityResponse();

            var client = new RestClient("https://dev.farizdotid.com/api/daerahindonesia/kota?id_provinsi=" + id_provinsi);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                stat.ResponseCode = StatusCodes.Status200OK;
                stat.ResponseMessage = "Success";
                resp.Status = stat;
                resp.Result = JsonConvert.DeserializeObject<CityListResponse>(response.Content);
            }

            return Ok(resp);
        }

        [HttpGet]
        [Route("subdistrict/{id_kota}")]
        public IActionResult GetAllSubdistrict(int id_kota)
        {
            var stat = new Status();
            var resp = new SubdistrictResponse();

            var client = new RestClient("https://dev.farizdotid.com/api/daerahindonesia/kecamatan?id_kota=" + id_kota);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                stat.ResponseCode = StatusCodes.Status200OK;
                stat.ResponseMessage = "Success";
                resp.Status = stat;
                resp.Result = JsonConvert.DeserializeObject<SubdistrictListResponse>(response.Content);
            }

            return Ok(resp);
        }
    }


}
