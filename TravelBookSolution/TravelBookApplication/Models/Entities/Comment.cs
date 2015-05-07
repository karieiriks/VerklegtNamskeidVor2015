using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Body { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual UserContent Content { get; set; }
    }
}