using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBookApplication.Models.ViewModels
{
	public class WelcomePageViewModel
	{
		public LoginViewModel LoginModel { get; set; }
		public RegisterViewModel RegisterModel { get; set; }
	}
}