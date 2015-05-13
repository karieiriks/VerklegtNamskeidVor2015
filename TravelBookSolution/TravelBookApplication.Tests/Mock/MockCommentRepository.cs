using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Tests.Mock
{
    public class MockCommentRepository : ICommentRepository
    {
        private List<Comment> com = new List<Comment>();

        public List<Comment> Comments
        {
            get { return com; }
            set { }
        }
        public Comment Save(Comment a)
        {
            Comments.Add(a);
            return a;
        }

        public void Delete(Comment a)
        {
            var s = (from x in Comments
                     where a.ID == x.ID
                     select a).SingleOrDefault();
            Comments.Remove(s);
        }
        
    }
}
