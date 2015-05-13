using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class UserContent
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string ProfileId { get; set; }
        public int? GroupId { get; set; }
        public string PhotoName { get; set; }
        public string StoryName { get; set; }
        public string StoryTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ApplicationUser Owner { get; set; }
        [ForeignKey("ProfileId")]
        public virtual ApplicationUser ProfileUser { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        public virtual List<Comment> Comments { get; set; }
        //public virtual Album Album { get; set; }
        //public virtual List<ApplicationUser> Likers { get; set; }
        //public virtual List<ApplicationUser> Sharers { get; set; }
    }

    public class ContentComparer : IEqualityComparer<UserContent>
    {
        public bool Equals(UserContent c1, UserContent c2)
        {
            return c1.Id == c1.Id;
        }

        public int GetHashCode(UserContent c)
        {
            return c.Id;
        }
    }
}