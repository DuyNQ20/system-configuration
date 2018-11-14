using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Models
{
    public class PersonalSettingGroup
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public int Order { get; set; }
    }
}
