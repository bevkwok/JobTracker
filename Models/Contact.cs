using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JobTracker.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "First Name :")]
        [Required(ErrorMessage = "Please put down contact's first name.")]
        public string ContactFirstName { get; set; }


        [Display(Name = "Last Name :")]
        public string ContactLastName { get; set; }


        [Display(Name = "Job Title :")]
        public string ContactTitle { get; set; }


        [Display(Name = "Email :")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone :")]
        public int ContactPhone { get; set; }


        [Display(Name = "Note :")]
        public string Note { get; set; }

        [Display(Name = "Thank you letter")]
        public bool ThankYouLetter { get; set; }

        public int JobId { get; set; }

        public Job WorkFor { get; set; }

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdateAt {get; set;} = DateTime.Now;
    }
}