using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Entity.Model
{
    [Table("Firmware")]
    public class Firmware
    {
        [Key]
        public string ID { get; set; }
        public bool FullPowerMode { get; set; }
        public bool ActivePowerControl { get; set; }
        public int FirmwareVersion { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }

        public string DeviceID { get; set; }
    }
}
