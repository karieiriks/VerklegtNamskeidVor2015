using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class Friendship
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public virtual  ApplicationUser User { get; set; }
        public virtual ApplicationUser Friend { get; set; }
    }
}