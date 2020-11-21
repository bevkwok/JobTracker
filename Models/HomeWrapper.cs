using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobTracker.Models;
namespace JobTracker.Models
{
    public class HomeWrapper 
    {
    public User TheUser { get; set; }
    public List<Job> JobList { get; set; }

    public List<Job> InterestedJob { get; set; }

    public List<Job> AppliedJob { get; set; }

    public List<Job> InterviewedJob { get; set; }

    }
}