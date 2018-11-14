using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Models
{
    public class UserSetting
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
