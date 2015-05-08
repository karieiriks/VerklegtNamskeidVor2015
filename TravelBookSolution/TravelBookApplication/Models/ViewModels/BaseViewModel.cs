using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.ViewModels
{
    public class BaseViewModel
    {
        public ApplicationUser UserDisplayed { get; set; }
        public Group GroupDisplayed { get; set; }
    }
}