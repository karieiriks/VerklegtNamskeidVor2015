﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class Message
    {
        public string Id { get; set; }
        public string About { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }

        public virtual ApplicationUser FromUser { get; set; }
        public virtual ApplicationUser ToUser { get; set; }
    }
}