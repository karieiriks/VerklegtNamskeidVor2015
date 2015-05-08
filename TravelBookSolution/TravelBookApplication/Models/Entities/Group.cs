﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class Group
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public int MemberCount { get; set; }
        public virtual List<ApplicationUser> Members { get; set; }
        public virtual List<ApplicationUser> MembersRequests { get; set; }
        //public virtual List<UserContent> GroupContent { get; set; }
    }
}