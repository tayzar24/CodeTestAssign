using Microsoft.Extensions.DependencyInjection;
using STPL.AppService.IService;
using STPL.AppService.Service;
using STPL.Core.IRepository;
using STPL.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.AppService.Extension
{
    public static class ServiceExtension
    {
        public static void AddService(this IServiceCollection services)
        {

            //// Repository
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IFirmwareRepository, FirmwareRepository>();
            services.AddScoped<IVersionInfoRepository, VersionRepository>();

            ////Service
            services.AddScoped<IDeviceAppService, DeviceAppService>();
        }
    }
   
}
