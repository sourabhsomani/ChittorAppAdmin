using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChittorAPPAdmin.Entities
{
    public class Districts
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string DistrictName { get; set; }
        [ForeignKey("States")]
        public string StateID { get; set; }
        public virtual State States { get; set; }
    }
}