using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Entity.Model
{
    [Table("Version")]
    public  class VersionData
    {
        [Key]
        public string ID { get; set; }
        public int Version { get; set; }
        public string MessageType { get; set; }
        public bool Occupancy { get; set; }
        public int StageChange { get; set; }
        public string DeviceID { get; set; }
        
    }
}
