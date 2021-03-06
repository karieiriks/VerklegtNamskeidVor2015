﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace TravelBookApplication.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserName { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "Confirm email")]
		[Compare("UserName", ErrorMessage = "The email and confirmation email do not match.")]
		public string ConfirmEmail { get; set; }

		[Required]
		[Display(Name = "Gender")]
		public string Gender { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required]
		[RegularExpression(@"[^0-9]+[àèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]*[a-zA-Z]*",
							ErrorMessage = "Name can not include numbers")]
		[MaxLength(20, ErrorMessage = "{0} can not be more than 20 characters long")]
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Required]
		[RegularExpression(@"[^0-9]+[àèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]*[a-zA-Z]*",
							ErrorMessage = "Name can not include numbers")]
		[MaxLength(20, ErrorMessage = "Last name can not be more than 20 characters long")]
		[Display(Name = "Last name")]
		public string LastName { get; set; }
		
		[Required]
		[MinAge(15, ErrorMessage = "You must be at least 15 years old to register")]
		[DataType(DataType.Date)]
		[Display(Name = "Birthday")]
		public DateTime DateOfBirth { get; set; }
    }
}
