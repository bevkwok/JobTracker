using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace JobTracker.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "First Name ")]
        [Required(ErrorMessage = "Please put down contact's first name.")]
        [MinLength(2, ErrorMessage = "First name must contain at least 2 character")]
        [MaxLength(46, ErrorMessage = "First name must be within 46 character")]

        public string ContactFirstName { get; set; }


        [Display(Name = "Last Name ")]
        [MinLength(1, ErrorMessage = "Last name must contain at least 2 character")]
        [MaxLength(46, ErrorMessage = "Last name must be within 46 character")]

        public string ContactLastName { get; set; }


        [Display(Name = "Job Title ")]
        [MaxLength(46, ErrorMessage = "Job title must be within 46 character")]
        public string ContactTitle { get; set; }


        [Display(Name = "Email ")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone ")]
        [MaxLength(16, ErrorMessage = "Phone must be within 46 character")]

        public string ContactPhone { get; set; }

        [Display(Name = "From Company ")]
        [MaxLength(46, ErrorMessage = "Company name must be within 46 character")]
        public string FromCompany { get; set; }

        [Display(Name = "Note ")]
        [MaxLength(500, ErrorMessage = "Note must be within 255 character")]
        public string Note { get; set; }

        [Display(Name = "Thank you letter")]
        // [Required(ErrorMessage = "Please select an option.")]
        public string ThankYouLetter { get; set; }

        public int UserId { get; set; }

        public User Candidate { get; set; }

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdateAt {get; set;} = DateTime.Now;
    }
}