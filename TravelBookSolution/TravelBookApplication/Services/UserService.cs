using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Services
{
    public class UserService
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void AddUser(ApplicationUser User)
        {// Test
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                db.Users.Add(User);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void AddFriendRequest(string fromUserId, string toUserId)
        {// Test
            var FromUser = (from users in db.Users
                            where users.Id == fromUserId
                            select users).SingleOrDefault();

            var ToUser = (from users in db.Users
                          where users.Id == toUserId
                          select users).SingleOrDefault();

            ToUser.FriendRequests.Add(FromUser);
            db.SaveChanges();
        }
    }
}