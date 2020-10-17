using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JobTracker.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }

        public int UserId {get; set;}

        public int JobId { get; set; }

        public User User { get; set; }

        public Job Job { get; set; }


    }
}