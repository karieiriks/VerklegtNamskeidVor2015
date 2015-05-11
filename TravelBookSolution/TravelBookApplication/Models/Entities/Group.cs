using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public int MemberCount { get; set; }
        public virtual List<Membership> Members { get; set; }
        public virtual List<MemberRequest> MembersRequests { get; set; }
        public virtual List<UserContent> GroupContent { get; set; }
    }
}