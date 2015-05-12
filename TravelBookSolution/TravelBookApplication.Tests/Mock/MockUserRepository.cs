using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Tests.Mock
{
    internal class MockUserRepository : IApplicationUserRepository
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

    }
}
