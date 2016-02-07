using ChittorAPPAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChittorAPPAdmin.Entities
{
    public class Area
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string AreaName { get; set; }
        [Required]
        public DateTime AreaAddedDate { get; set; }

        [Required]
        public DateTime AreaModifiedDate { get; set; }
        [Required]
        public string AreaAddedBy { get; set; }
        [Required]
        public string AreaModifiedBy { get; set; }

        [ForeignKey("District")]
        public string DistrictID { get; set; }
        public virtual Districts District { get; set; }
    }
}