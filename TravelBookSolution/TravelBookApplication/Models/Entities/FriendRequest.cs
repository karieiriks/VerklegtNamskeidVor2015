using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class FriendRequest
    {
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }

        public virtual ApplicationUser ToUser { get; set; }
        public virtual ApplicationUser FromUser { get; set; }
    }
}