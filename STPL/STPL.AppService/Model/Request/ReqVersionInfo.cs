using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.AppService.Model.Request
{
    public  class ReqVersionInfo : DeviceInfo
    {
        public VersionInfo Data { get; set; }
    }

    public class VersionInfo
    {
        public int Version { get; set;}
        public string MessageType { get; set;}
        public bool Occupancy { get; set;}
        public int StageChange { get; set;}
    }
}
