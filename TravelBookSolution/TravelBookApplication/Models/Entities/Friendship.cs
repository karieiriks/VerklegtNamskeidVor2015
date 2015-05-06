using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class Friendship
    {
        public int UserOneID { get; set; }
        public int UserTwoID { get; set; }

        public virtual ApplicationUser UserOne { get; set; }
        public virtual ApplicationUser UserTwo { get; set; }
    }
}