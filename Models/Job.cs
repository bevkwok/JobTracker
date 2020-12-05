using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JobTracker.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }


        [Required]
        [MinLength(2, ErrorMessage = "Company name must be at least 2 character")]
        [MaxLength(46, ErrorMessage = "Company name must be within 46 character")]
        [Display(Name = "* Company Name")]
        public string CompanyName { get; set; }


        [Required]
        [MinLength(2, ErrorMessage = "Job title must be at least 2 character")]
        [MaxLength(46, ErrorMessage = "Job title name must be within 46 character")]

        [Display(Name = "* Job Title")]
        public string JobTitle { get; set; }


        [Required]
        [Display(Name = "* Status")]
        public string JobStatus { get; set; }

        [Display(Name = "Applied At")]
        [MaxLength(46, ErrorMessage = "Applied site name must be within 46 character")]
        public string AppliedAt { get; set; }
        
        [Required]
        [Display(Name = "Date Applied")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AppliedDate { get; set; }


        [Display(Name = "Job Type")]
        [MaxLength(46, ErrorMessage = "Job type must be within 46 character")]
        public string JobType { get; set; }


        [Display(Name = "Company Website")]
        [MaxLength(555, ErrorMessage = "Required Skill must be within 555 character")]
        public string CompanyWebsite { get; set; }

        [Display(Name = "Application Link")]
        [MaxLength(755, ErrorMessage = "Required Skill must be within 755 character")]
        [Column("ApplicationLink", TypeName = "LONGTEXT")]
        public string ApplicationLink { get; set; }


        [Display(Name = "Required Skill")]
        [MaxLength(255, ErrorMessage = "Required Skill must be within 255 character")]

        public string RequiredSkill { get; set; }


        [Display(Name = "Note")]
        [MaxLength(500, ErrorMessage = "Note must be within 500 character")]
        [Column("JobNote", TypeName = "LONGTEXT")]

        public string JobNote { get; set; }

        public int UserId { get; set; }

        public User SavedBy { get; set; }

        public List<Contact> JobContact { get; set; }

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdateAt {get; set;} = DateTime.Now;

    }
}