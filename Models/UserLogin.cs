using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JobTracker.Models
{
    public class UserLogin
    {
        [Display(Name="Email :")]
        [Required(ErrorMessage = "Email is required")]
        public string LogEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name="Password :")]
        // [DataType(DataType.Password)]
        public string LogPassword {get; set;}
    }
}