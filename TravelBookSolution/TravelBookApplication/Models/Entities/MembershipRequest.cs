using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class MembershipRequest
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Group Group { get; set; }
    }
}