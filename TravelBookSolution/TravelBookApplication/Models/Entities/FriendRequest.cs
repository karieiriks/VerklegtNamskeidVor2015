using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class FriendRequest
    {
        public int UserID { get; set; }
        public int FutureFriendID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser FutureFriend { get; set; }
    }
}