using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class Group
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public int MemberCount { get; set; }
        public virtual ICollection<ApplicationUser> Members { get; set; }
        public virtual ICollection<ApplicationUser> MembersRequests { get; set; }
    }
}