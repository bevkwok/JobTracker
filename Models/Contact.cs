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
        public string ContactFirstName { get; set; }


        [Display(Name = "Last Name ")]
        [MinLength(1, ErrorMessage = "Last name must contain at least 2 character")]
        public string ContactLastName { get; set; }


        [Display(Name = "Job Title ")]
        public string ContactTitle { get; set; }


        [Display(Name = "Email ")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone ")]
        public string ContactPhone { get; set; }

        [Display(Name = "From Company ")]
        public string FromCompany { get; set; }

        [Display(Name = "Note ")]
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