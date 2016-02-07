using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChittorAPPAdmin.Entities
{
    public class Bussiness
    {
        [Key]
        public string ID { get; set; }
        public string BussinessName { get; set; }
        public string BussinessDetails { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string mobile2 { get; set; }
        public string Fax { get; set; }
        public string  Address { get; set; }
        /////////////////Foreign Key///////////////////
        [ForeignKey("Category")]
        public string CategoryID { get; set; }
        [ForeignKey("States")]
        public string StateID { get; set; }
        [ForeignKey("Districts")]
        public string DistrictID { get; set; }
        [ForeignKey("Areas")]
        public string AreaID { get; set; }
        [ForeignKey("SubAreas")]
        public string SubAreaID { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Districts Districts { get; set; }
        public virtual State States { get; set; }
        public virtual Area Areas { get; set; }
        public virtual SubArea SubAreas { get; set; }

        ////////////////End Foreign Key////////////////
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime ExpiryDate  { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}