using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class MemberRequest
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}