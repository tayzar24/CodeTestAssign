using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.AppService.Model.Request
{
    public class ReqDevice : DeviceInfo
    {
        public Data Data { get; set; }
    }

    public class DeviceInfo
    {
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string DeviceName { get; set; }
        public string GroupId { get; set; }
        public string DataType { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Data
    {
        public bool FullPowerMode { get; set;}
        public bool ActivePowerControl { get; set;}
        public int FirmwareVersion { get; set;}
        public int Tempeature { get; set;}
        public int Humidity { get; set;}
    }

}
