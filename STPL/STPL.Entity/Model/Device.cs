using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Entity.Model
{
    [Table("Device")]
    public class Device
    {
        [Key]
        public string ID { get; set; }
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string GroupID { get; set; }
        public string DataType { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
