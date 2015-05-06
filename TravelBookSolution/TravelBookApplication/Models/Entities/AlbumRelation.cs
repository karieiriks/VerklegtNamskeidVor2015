using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.Entities
{
    public class AlbumRelation
    {
        public int AlbumID { get; set; }
        public int ContentID { get; set; }

        public virtual Album Album { get; set; }
        public virtual UserContent Content { get; set; }
    }
}