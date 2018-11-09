using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Configuration.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class File
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Extention { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UploadedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UploadedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Hash { get; set; }

    }
}
