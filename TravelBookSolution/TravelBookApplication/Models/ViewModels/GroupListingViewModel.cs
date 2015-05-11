using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.ViewModels
{
    public class GroupListingViewModel : BaseViewModel
    {
        public List<Group> UserGroups { get; set; }
        public List<Group> AllGroups { get; set; }
    }
}