using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Tests.Mock
{
     public class MockUserRepository : IApplicationUserRepository
    {
        private List<ApplicationUser> use = new List<ApplicationUser>();

        public List<ApplicationUser> Users
        {
            get { return use; }
            set { }
        }

        public ApplicationUser Save(ApplicationUser user)
        {
            Users.Add(user);
            return user;
        }

        public void Delete(ApplicationUser user)
        {
            var item = (from x in Users
                where user.Id == x.Id
                select x).SingleOrDefault();
            Users.Remove(item);
        }
        public ApplicationUser GetUserById(string Id, IApplicationUserRepository db)
        {

            var user = (from users in db.Users
                        where users.Id == Id
                        select users).SingleOrDefault();

            return user;
        }
        public List<ApplicationUser> GetUsersBySubstring(string value, IApplicationUserRepository db)
        {
            var users = (from u in db.Users.Where(a => a.FullName.Contains(value))
                         select u).ToList();

            return users;
        }

    }
}
