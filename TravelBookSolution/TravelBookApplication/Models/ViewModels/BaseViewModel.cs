﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.ViewModels
{
    public class BaseViewModel
    {
        private string imageDirectory = ConfigurationManager.AppSettings.Get("ImageDirectory");
        public ApplicationUser UserDisplayed { get; set; }
        public Group GroupDisplayed { get; set; }

        public string ImageDirectory 
        { 
            get
            {
                return imageDirectory;
            }

            set
            {
                imageDirectory = value;
            }
        }
    }
}