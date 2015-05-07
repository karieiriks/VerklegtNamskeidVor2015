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
        [Key, Column(Order = 1)]
        public string UserOneID { get; set; }
        [Key, Column(Order = 2)]
        public string UserTwoID { get; set; }

        [ForeignKey("UserOneID")]
        public virtual  ApplicationUser UserOne { get; set; }
        [ForeignKey("UserTwoID")]
        public virtual ApplicationUser UserTwo { get; set; }
    }
}