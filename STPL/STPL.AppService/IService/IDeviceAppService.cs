using STPL.AppService.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.AppService.IService
{
    public interface IDeviceAppService 
    {
        Task<string> PayloadOneService(ReqDevice input);
        Task<string> PayloadTwoService(ReqVersionInfo input);
    }
}
