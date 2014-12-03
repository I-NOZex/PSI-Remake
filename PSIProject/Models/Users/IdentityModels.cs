using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using PSIProject.Models.Locations;
using System.ComponentModel.DataAnnotations;
using PSIProject.Models.Auctions;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PSIProject.Models.Users {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //public 

        public string Name { get; set; }

        public string Photo { get; set; }

        /*public int PostalCodeID { get; set; }

        [ForeignKey("PostalCodeID")]
        public virtual PostalCode PostalCode { get; set; }*/

        public virtual ICollection<Auction> Auctions { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }

        public virtual ICollection<BlockHistory> Blocks { get; set; }

        //public virtual ICollection<Sale> Sales { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {

        //public DbSet<PostalCode> PostalCode { get; set; }

        public ApplicationDbContext()
            // ConnectionString
            : base("AuctionsContext", throwIfV1Schema: false)
        {
        }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostalCode>().HasMany(x => x.Users).WithMany();
            modelBuilder.Entity<PostalCode>()
                .HasRequired(s => s.Users)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}