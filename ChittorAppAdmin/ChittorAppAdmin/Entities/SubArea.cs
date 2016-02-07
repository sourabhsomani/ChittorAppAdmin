using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChittorAPPAdmin.Entities
{
    public class SubArea
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string SubAreaName { get; set; }
        [ForeignKey("Areas")]
        public string AreaID { get; set; }
        [Required]
        public string AddedBy { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public string AddedDate { get; set; }
        [Required]
        public string ModifiedDate { get; set; }
        public virtual Area Areas{ get; set; }
    }
}