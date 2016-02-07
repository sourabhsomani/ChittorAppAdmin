using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChittorAPPAdmin.Entities
{
    public class Categories
    {   
        [Key] 
        public string ID { get; set; }
        [Required(ErrorMessage="Please Enter Category Name")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        public DateTime AddedDate { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public String AddedBy { get; set; }
        [Required]
        public String ModifiedBy { get; set; }

    }
}