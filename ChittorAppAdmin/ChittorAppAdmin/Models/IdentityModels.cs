using ChittorAPPAdmin.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ChittorAPPAdmin.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<SubArea> SubAreas { get; set; }
        public virtual DbSet<Bussiness> Bussiness { get; set; }
        
    }
}