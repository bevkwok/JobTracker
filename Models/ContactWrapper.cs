using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobTracker.Models;
namespace JobTracker.Models
{
    public class ContactWrapper 
    {
    public User TheUser { get; set; }

    public Contact TheContact { get; set; }
    public List<Contact> ContactList { get; set; }

    }
}