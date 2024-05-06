using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STPL.AppService.IService;
using STPL.AppService.Model.Request;
using STPL.AppService.Model.Response;
using STPL.Common.CustomError;
using System.Net;

namespace STPL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceAppService _deviceAppService;

        public DeviceController(IDeviceAppService deviceAppService)
        {
           _deviceAppService = deviceAppService;    
        }
        [HttpPost("PayLoadOne")]
        public async Task<IActionResult> PayLoadOne([FromBody] ReqDevice input)
        {
            int statusCode = (int)HttpStatusCode.OK;
            ResDevice response = new ResDevice();
            try
            {
                response.Data = await _deviceAppService.PayloadOneService(input);

            }catch (ErrorException ex)
            {
                statusCode = ex.StatusCode;
                response.ErrorInfo = ex.ErrorInfo;
            }
            return new ObjectResult(response) { StatusCode = statusCode };
        }


        [HttpPost("PayLoadTwo")]
        public async Task<IActionResult> PayLoadTwo([FromBody] ReqVersionInfo input)
        {
            int statusCode = (int)HttpStatusCode.OK;
            ResDevice response = new ResDevice();
            try
            {
                response.Data = await _deviceAppService.PayloadTwoService(input);

            }
            catch (ErrorException ex)
            {
                statusCode = ex.StatusCode;
                response.ErrorInfo = ex.ErrorInfo;
            }
            return new ObjectResult(response) { StatusCode = statusCode };
        }
    }
}
