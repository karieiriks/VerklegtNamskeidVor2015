using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TravelBookApplication.Models.Entities;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace TravelBookApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string ProfileImageName { get; set; }
        public string Gender { get; set; }
        public  DateTime DateOfBirth { get; set; }
		public string FullName { get; set; }

        public virtual List<UserContent> Content { get; set; }
        public virtual List<Friendship> Friends { get; set; }
        public virtual List<FriendRequest> FriendRequests { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        //public DbSet<Message> Messages { get; set; }
        public DbSet<UserContent> Content { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<MemberRequest> MemberRequests { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(s => s.Content)
                .WithRequired(s => s.Owner)
                .HasForeignKey(s => s.OwnerId);

            modelBuilder.Entity<UserContent>()
                .HasOptional(s => s.ProfileUser);

            modelBuilder.Entity<Friendship>().HasKey(f => new { f.UserId, f.FriendId });
            modelBuilder.Entity<Friendship>()
                .HasRequired(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Friendship>()
                .HasRequired(f => f.Friend)
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FriendRequest>().HasKey(r => new { r.ToUserId, r.FromUserId });
            modelBuilder.Entity<FriendRequest>()
                .HasRequired(r => r.ToUser)
                .WithMany()
                .HasForeignKey(r => r.ToUserId);

            modelBuilder.Entity<FriendRequest>()
                .HasRequired(r => r.FromUser)
                .WithMany()
                .HasForeignKey(r => r.FromUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.GroupContent);

            modelBuilder.Entity<MemberRequest>().HasKey(r => new { r.GroupId, r.UserId });
            modelBuilder.Entity<MemberRequest>()
                .HasRequired(r => r.Group)
                .WithMany()
                .HasForeignKey(r => r.GroupId);

            modelBuilder.Entity<MemberRequest>()
                .HasRequired(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Membership>().HasKey(r => new { r.GroupId, r.UserId });
            modelBuilder.Entity<Membership>()
                .HasRequired(r => r.Group)
                .WithMany()
                .HasForeignKey(r => r.GroupId);

            modelBuilder.Entity<Membership>()
                .HasRequired(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .WillCascadeOnDelete(false);

	        modelBuilder.Entity<Comment>().HasKey(c => c.Id);
	        modelBuilder.Entity<Comment>()
		        .HasRequired(c => c.User)
		        .WithMany()
		        .HasForeignKey(c => c.UserId);

	        modelBuilder.Entity<Comment>()
		        .HasRequired(c => c.Content)
		        .WithMany(c => c.Comments)
		        .HasForeignKey(c => c.ContentId)
				.WillCascadeOnDelete(false);
        }
    }
}