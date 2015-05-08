using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class UserContent
    {
        public string ID { get; set; }

        // The User who posted
        public string OwnerID { get; set; }
        public string PhotoName { get; set; }
        public string StoryName { get; set; }
        public string StoryTitle { get; set; }
        public string PostConent { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ApplicationUser Owner { get; set; }
        //public virtual List<Comment> Comments { get; set; }

        //public virtual ApplicationUser ProfileUser { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual Album Album { get; set; }
        //public virtual List<ApplicationUser> Likers { get; set; }
        //public virtual List<ApplicationUser> Sharers { get; set; }
    }
}