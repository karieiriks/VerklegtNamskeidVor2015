using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Tests.Mock
{
    class MockGroupRepository : IGroupRepository
    {
        private List<Group> gru = new List<Group>();

        public List<Group> Groups
        {
            get { return gru;}
            set { }
        }

        public Group Save(Group a)
        {
            Groups.Add(a);
            return a;
        }

        public void Delete(Group a)
        {
            var s = (from x in Groups
                where a.Id == x.Id
                select a).SingleOrDefault();
            Groups.Remove(s);

        }
        
        public Group GetGroupById(int id)
        {
            return (from x in gru
                    where x.Id == id
                    select x).SingleOrDefault();
        }
    }
}
