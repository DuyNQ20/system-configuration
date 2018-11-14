using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Models
{
    public class PersonalSettingDescription
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public bool Data { get; set; }
        public int LanguageID { get; set; }
    }
}
