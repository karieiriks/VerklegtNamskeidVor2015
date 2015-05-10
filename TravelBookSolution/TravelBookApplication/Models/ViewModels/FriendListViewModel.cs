using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.ViewModels
{
    public class FriendListViewModel : BaseViewModel
    {
        public List<ApplicationUser> FriendRequests { get; set; }
        public List<ApplicationUser> Friends { get; set; }
    }
}