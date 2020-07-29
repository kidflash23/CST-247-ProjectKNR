using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        
        
        [Required]
        [DisplayName("User Name")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public string Username { get; set; }
        
        [DisplayName("Password")]
        [Required(ErrorMessage = "You must have a password.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4, ErrorMessage ="Password too short, at least 4 characters")]
        public string Password { get; set; }
        
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords did not match.")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address required.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email Address")]
        [Compare("EmailAddress", ErrorMessage ="Email didn't match.")]
        public string EmailConfirmation { get; set; }


    }
}