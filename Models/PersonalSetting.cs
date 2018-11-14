using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Models
{
    public class PersonalSetting
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string Key { get; set; }
        public string DataType { get; set; }

        public int SystemSettingGroupID { get; set; }
        public SystemSettingGroup SystemSettingGroup { get; set; }
    }
}
