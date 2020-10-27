using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobTracker.Models;
namespace JobTracker.Models
{
    public class AddJobWrapper 
    {
    public User TheUser { get; set; }
    public Job TheJob { get; set; }
    }
}