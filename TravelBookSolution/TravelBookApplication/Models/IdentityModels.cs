﻿using Microsoft.AspNet.Identity.EntityFramework;
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
        public string Email { get; set; }
        public string ProfileImageName { get; set; }
        public string Gender { get; set; }
        public  DateTime DateOfBirth { get; set; }

        /*public virtual List<ApplicationUser> FriendRequests { get; set; }
        public virtual List<ApplicationUser> Friends { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual List<Group> GroupRequests { get; set; }
        public virtual List<UserContent> Content { get; set; }

        /*public virtual List<Album> Albums { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual List<UserContent> Content { get; set; }
        public virtual List<Friendship> Friends { get; set; }
        public virtual List<FriendRequest> FriendRequests { get; set; }
        public virtual List<Message> Messages { get; set; }*/
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<Album> Albums { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Group> Groups { get; set; }
        //public DbSet<Message> Messages { get; set; }
        //public DbSet<UserContent> Content { get; set; }
        //public DbSet<FriendRequest> FriendRequests { get; set; }
        //public DbSet<Friendship> Friendships { get; set; }

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
            /*
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(s => s.FriendRequests)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("FromUserID");
                    m.MapRightKey("ToUserID");
                    m.ToTable("FriendRequests");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(s => s.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("FriendID");
                    m.MapRightKey("FriendeeID");
                    m.ToTable("Friendships");
                });

            modelBuilder.Entity<Group>()
                .HasMany(s => s.Members)
                .WithMany(s => s.Groups)
                .Map(m =>
                {
                    m.MapLeftKey("MemberId");
                    m.MapRightKey("GroupId");
                    m.ToTable("GroupMemberships");
                });

            modelBuilder.Entity<Group>()
                .HasMany(s => s.MembersRequests)
                .WithMany(s => s.GroupRequests)
                .Map(m =>
                {
                    m.MapLeftKey("RequestId");
                    m.MapRightKey("GroupId");
                    m.ToTable("GroupMemberRequests");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(s => s.Content)
                .WithRequired(s => s.Owner)
                .HasForeignKey(s => s.OwnerID);

            /*modelBuilder.Entity<UserContent>()
                .HasRequired(s => s.Owner)
                .WithMany(s => s.Content);

            modelBuilder.Entity<UserContent>()
                .HasMany(s => s.Comments);

            modelBuilder.Entity<Comment>()
                .HasKey(s => s.ID)
                .HasRequired(s => s.User)
                .WithRequiredDependent();*/
        }
    }
}