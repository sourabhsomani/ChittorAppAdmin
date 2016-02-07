using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChittorAPPAdmin.Entities
{
    public class State
    {
        [Key]
        public string StateID { get; set; }
        [Required]
        public string StateName { get; set; }

    }
}