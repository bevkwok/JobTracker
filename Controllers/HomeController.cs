﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using JobTracker.Models;

namespace JobTracker.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost("creat_user")]
        public IActionResult CreateUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return Register();
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                int? theUserId = HttpContext.Session.GetInt32("UserId");
                return RedirectToAction("Home",new{UserId = theUserId}); 
            }
            else
            {
                return Register();
            }
        }

        [HttpGet("signin")]
        public IActionResult Signin()
        {
            return View("Signin");
        }


        [HttpPost("login")]
        public IActionResult Login(UserLogin loginUser)
        {
            User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == loginUser.LogEmail);

            if(userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");

                return Signin();
            }

            var hasher = new PasswordHasher<User>();

            var result =  hasher.VerifyHashedPassword(userInDb, userInDb.Password, loginUser.LogPassword);

            if(result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");

                return Signin();
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            return RedirectToAction("Home",new{UserId = theUserId});
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["OneUser.FirstName"] = "Please signin or register";
            return RedirectToAction("Signin");
        }

        [HttpGet("home/{UserId}")]
        public IActionResult Home(int UserId)
        {   
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Id = theUserId;

            if(theUserId == null)
            {
                return Logout();
            }

            HomeWrapper HomeWMod = new HomeWrapper();

            HomeWMod.TheUser = dbContext.Users
                .Include(user => user.AppliedJobs)
                .ThenInclude(j => j.JobContact)
                .FirstOrDefault(u => u.UserId == theUserId);

            HomeWMod.JobList = dbContext.Jobs
                .Where(jsu => jsu.UserId == theUserId)
                .ToList();

            return View("Home", HomeWMod);
        }

        [HttpGet("{UserId}/job/list")]
        public IActionResult JobList()
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Id = theUserId;


            if(theUserId == null)
            {
                return Logout();
            }

            HomeWrapper HomeWMod = new HomeWrapper();

            HomeWMod.TheUser = dbContext.Users
                .Include(user => user.AppliedJobs)
                .ThenInclude(j => j.JobContact)
                .FirstOrDefault(u => u.UserId == theUserId);

            HomeWMod.JobList = dbContext.Jobs
                .Where(jsu => jsu.UserId == theUserId)
                .ToList();

            return View("JobList", HomeWMod);
        }

        [HttpGet("{UserId}/add_job")]
        public IActionResult AddJob()
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Id = theUserId;


            User activeUser = dbContext.Users.FirstOrDefault(u => u.UserId == theUserId);

            if(theUserId == null)
            {
                return Logout();
            }
            
            return View("AddJob");
        }

        [HttpPost("add_job/new")]
        public IActionResult AddNewJob(Job NewJob)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            

            User activeUser = dbContext.Users.FirstOrDefault(u => u.UserId == theUserId);

            if(theUserId == null)
            {
                return Logout();
            }

            if(ModelState.IsValid)
            {
                NewJob.UserId = (int)theUserId;
                dbContext.Add(NewJob);
                dbContext.SaveChanges();
                return RedirectToAction("Home",new{UserId = theUserId});
            }
            return AddJob();
        }



        [HttpGet("{UserId}/personal_info")]
        public IActionResult PersonalInfo()
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Id = theUserId;

            // if(theUserId == null)
            // {
            //     return Logout();
            // }

            User loginUser = dbContext.Users
                .Include(user => user.AppliedJobs)
                .ThenInclude(j => j.JobContact)
                .FirstOrDefault(u => u.UserId == theUserId);

            return View("PersonalInfo", loginUser);
        }

        [HttpPost("edit/user/{UserId}")]
        public IActionResult EditUser(User EditedUser, string OldPassword)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");

            User loginUser = dbContext.Users
                .FirstOrDefault(u => u.UserId == theUserId);

            PasswordHasher<User> Hasher = new PasswordHasher<User>();

            var result =  Hasher.VerifyHashedPassword(loginUser, loginUser.Password, OldPassword);

            if(result == 0)
            {
                ModelState.AddModelError("Password", "Incorrect old password!");

                return PersonalInfo();
            }

            if(ModelState.IsValid)
            {

                EditedUser.Password = Hasher.HashPassword(EditedUser, EditedUser.Password);

                if(dbContext.Users.Any(u => u.Email == EditedUser.Email) && EditedUser.Email != loginUser.Email)
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return PersonalInfo();
                }
                loginUser.Username = EditedUser.Username;
                loginUser.Email = EditedUser.Email;
                loginUser.Password = EditedUser.Password;
                loginUser.UpdateAt = DateTime.Now;

                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", EditedUser.UserId);

                return RedirectToAction("Home",new{UserId = theUserId}); 
            }
            else
            {
                return PersonalInfo();
            }
        }

        [HttpGet("/job/delete/{id}")]
        public IActionResult DeleteJob(int id)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Id = theUserId;

            if(theUserId == null)
            {
                return Logout();
            }
            Job ToDelete = dbContext.Jobs
            .FirstOrDefault(w => w.JobId == id);

            if(ToDelete == null || ToDelete.UserId != (int)theUserId)
            {
                return RedirectToAction("Home",new{UserId = theUserId});
            }
            dbContext.Remove(ToDelete);
            dbContext.SaveChanges();

            return RedirectToAction("Dashboard",new{UserId = theUserId});
        }

        [HttpGet("job/detail/{JobId}")]
        public IActionResult JobDetail(int? JobId)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Id = theUserId;

            if(theUserId == null)
            {
                return Logout();
            }

            Job theJob = dbContext.Jobs 
            .Include(j => j.JobContact)
            .FirstOrDefault(tj => tj.JobId == JobId);

            return View("JobDetail", theJob);
        }

        [HttpGet("job/contact/{UserId}")]
        public IActionResult JobContact(int UserId)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Id = theUserId;

            if(theUserId == null)
            {
                return Logout();
            }
            
            ContactWrapper ContactWMod = new ContactWrapper();

            ContactWMod.TheUser = dbContext.Users
                .Include(user => user.Contacts)
                .FirstOrDefault(u => u.UserId == theUserId);

            ContactWMod.ContactList = dbContext.Contacts
                .Where(jsu => jsu.UserId == theUserId)
                .ToList();

            return View("JobContact", ContactWMod);
        }

        [HttpGet("{UserId}/add_job_contact")]
        public IActionResult AddJobContact()
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Id = theUserId;


            User activeUser = dbContext.Users.FirstOrDefault(u => u.UserId == theUserId);

            if(theUserId == null)
            {
                return Logout();
            }
            
            return View("AddJobContact");
        }

        [HttpPost("add_contact/new")]
        public IActionResult AddNewContact(Contact NewContact)
        {
            int? theUserId = HttpContext.Session.GetInt32("UserId");

            User activeUser = dbContext.Users.FirstOrDefault(u => u.UserId == theUserId);

            if(theUserId == null)
            {
                return Logout();
            }

            if(ModelState.IsValid)
            {
                NewContact.UserId = (int)theUserId;
                dbContext.Add(NewContact);
                dbContext.SaveChanges();
                return RedirectToAction("JobContact",new{UserId = theUserId});
            }
            return AddJobContact();
        }
    }
}