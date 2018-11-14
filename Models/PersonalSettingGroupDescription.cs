using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Models
{
    public class PersonalSettingGroupDescription
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int PersonalSettingGroupID { get; set; }
        public PersonalSettingGroup PersonalSettingGroup { get; set; }
    }
}
