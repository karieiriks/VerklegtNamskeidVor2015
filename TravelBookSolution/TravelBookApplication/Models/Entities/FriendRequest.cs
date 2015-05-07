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
        [Key, Column(Order = 1)]
        public string UserOneID { get; set; }
        [Key, Column(Order = 2)]
        public string UserTwoID { get; set; }

        [ForeignKey("UserOneID")]
        public ApplicationUser UserOne { get; set; }

        [ForeignKey("UserTwoID")]
        public ApplicationUser UserTwo { get; set; }
    }
}