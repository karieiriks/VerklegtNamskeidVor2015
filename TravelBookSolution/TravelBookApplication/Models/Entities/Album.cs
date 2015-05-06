using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TravelBookApplication.Models.Entities
{
    public class Album
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int ImageCount { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}