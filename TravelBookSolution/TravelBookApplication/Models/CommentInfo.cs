using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models
{
	public class CommentInfo : UserDisplayInfo
	{
		public string Body  { get; set; }
		public string TimePosted { get; set; }
	}
}