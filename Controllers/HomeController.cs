using System;
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
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("creat_user")]
        public IActionResult CreateUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return RedirectToAction("Register");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                int? theUserId = HttpContext.Session.GetInt32("UserId");
                return RedirectToAction("Home",new{UserId = theUserId}); //
            }
            else
            {
                return View("Register"); //the dashboard name
            }
        }

        [HttpGet("signin")]
        public IActionResult Signin()
        {
            return View();
        }


        [HttpPost("login")]
        public IActionResult Login(UserLogin loginUser)
        {
            User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == loginUser.LogEmail);

            if(userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return RedirectToAction("Signin");
            }

            var hasher = new PasswordHasher<User>();

            var result =  hasher.VerifyHashedPassword(userInDb, userInDb.Password, loginUser.LogPassword);

            if(result == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return RedirectToAction("Signin");
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

        [HttpGet("Home/{UserId}")]
        public IActionResult Home(int UserId)
        {   
            int? theUserId = HttpContext.Session.GetInt32("UserId");

            // if(theUserId == null)
            // {
            //     return Logout();
            // }

            User loginUser = dbContext.Users.FirstOrDefault(u => u.UserId == theUserId);


            return View("Home", loginUser);
        }
    }
}
