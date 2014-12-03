using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PSIProject.Models.Settings;
using PSIProject.Models.Users;
using PSIProject.Models.Locations;
using PSIProject.Models.Auctions;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.ModelConfiguration;

namespace PSIProject.DAL
{
    public class AuctionsContext : DbContext
    {

        public AuctionsContext()
            : base("AuctionsContext")
        {
        }

        public DbSet<BidIncrement> BidInc { get; set; }
        public DbSet<PointsTable> PointsTable { get; set; }
        public DbSet<Text> Text { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Locality> Locality { get; set; }
        public DbSet<PostalCode> PostalCode {get; set;}
        public DbSet<Auction> Auction { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ConfirmSale> ConfirmSale { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<BlockHistory> BlockHistory { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<FeedbackEvaluation> FeedbackEvaluation { get; set; }
        public DbSet<FeedbackItem> FeedbackItem { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<RateHistory> RateHistory { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ReportedAuction> ReportedAuction { get; set; }

        //public DbSet<IdentityUserLogin> AspNetUserLogin { get; set; }
        //public DbSet<IdentityRole> AspNetRole { get; set; }
        //public DbSet<IdentityUserRole> AspNetUserRole { get; set; }
        //public DbSet<IdentityUser> AspNetUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            if (modelBuilder == null) {
                throw new ArgumentNullException("modelBuilder");
            }

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Keep this:
            /*modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");*/
            //modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");

            /*// Change TUser to ApplicationUser everywhere else - 
            // IdentityUser and ApplicationUser essentially 'share' the AspNetUsers Table in the database:
            //EntityTypeConfiguration<ApplicationUser> table =
            //    modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            //table.Property((ApplicationUser u) => u.UserName).IsRequired();

            /*********/
            /*modelBuilder.Entity<Bid>()
                .HasRequired(s => s.UserID)
                .WithMany()
                .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<Auction>()
                .HasRequired(s => s.PostalCode)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bid>()
                .HasRequired(s => s.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.Seller)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.Buyer)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConfirmSale>()
                .HasRequired(s => s.Buyer)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConfirmSale>()
                .HasRequired(s => s.Seller)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReportedAuction>()
                .HasRequired(s => s.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasRequired(s => s.Classified)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasRequired(s => s.Classifier)
                .WithMany()
                .WillCascadeOnDelete(false);
            /*********/
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            // Configure the primary key for the Users 
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasKey(t => t.Id);

            //one-to-many
            /*modelBuilder.Entity<ApplicationUser>()
                .HasMany<Bid>(s => s.Bids)
                .WithRequired(s => s.User)
                .HasForeignKey(s => s.UserID);*/

            //http://msdn.microsoft.com/en-us/data/jj591620#ManyToMany

            /*modelBuilder.Entity<Auction>()
            .HasMany(c => c.Tags).WithMany(i => i.Auctions)
            .Map(t => t.MapLeftKey("AuctionID")
                .MapRightKey("TagID")
                .ToTable("AuctionTags"));
            */
        }
    }
}