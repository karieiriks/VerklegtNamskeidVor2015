using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public string ProfileImageName { get; set; }
        public string Gender { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public virtual ICollection<Album> UserAlbums { get; set; }
        public virtual ICollection<Comment> UserComments { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<UserContent> Content { get; set; }
        public virtual ICollection<ApplicationUser> Friends { get; set; }
        public virtual ICollection<ApplicationUser> FriendRequests { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<Album> Albums { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<UserContent> Content { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}