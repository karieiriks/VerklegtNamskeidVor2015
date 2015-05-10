using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.ViewModels
{
    public class ImageListingViewModel : BaseViewModel
    {
        public List<UserContent> Images { get; set; }
    }
}