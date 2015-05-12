using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.ViewModels
{
    public class MemberListingViewModel : BaseViewModel
    {
        public List<MemberRequest> Requests { get; set; }
        public List<Membership> Members { get; set; }
    }
}