using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.ViewModels
{
    public class NewsFeedViewModel : BaseViewModel
    {
        public List<UserContent> Content { get; set; }
		public List<Comment> Comments { get; set; } 
    }
}