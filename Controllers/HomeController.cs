using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BeltExam.Controllers
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

        [HttpPost("register")]
        public IActionResult Register(User thisUser)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(u => u.Email == thisUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                thisUser.Password = Hasher.HashPassword(thisUser, thisUser.Password);
                dbContext.Users.Add(thisUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", thisUser.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.LogEmail);
                if (userInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LogPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LogPassword", "Invalid Email/Password");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                ModelState.AddModelError("LogEmail", "You must be logged in first");
                return View("Index");
            }
            int someUser = (int)HttpContext.Session.GetInt32("UserId");
            User thisUser = dbContext.Users.FirstOrDefault(u => u.UserId == someUser);
            ViewBag.User = thisUser;
            List<Act> AllActivities = dbContext.Acts
                .Include(a => a.Creator)
                .Include(activity => activity.Participants)
                .OrderBy(act => act.Date)
                .ThenBy(a => a.Time)
                .ToList();
            foreach (var activity in AllActivities)
            {
                if (activity.Date < DateTime.Now)
                {
                    dbContext.Acts.Remove(activity);
                    dbContext.SaveChanges();
                }
            }
            return View(AllActivities);
        }

        [HttpGet("new")]
        public IActionResult New()// displays form to create a new activity
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Act newAct)
        {
            int thisUserId = (int)HttpContext.Session.GetInt32("UserId");
            if (ModelState.IsValid)
            {
                newAct.UserId = thisUserId;
                dbContext.Acts.Add(newAct);
                dbContext.SaveChanges();
                return RedirectToAction("Show", new { activityId = newAct.ActivityId });
            }
            return View("New");
        }

        [HttpGet("/activity/{activityId}")]
        public IActionResult Show(int activityId)
        {
            Act retrievedActivity = dbContext.Acts
                .Include(a => a.Creator)
                .Include(activity => activity.Participants)
                .ThenInclude(p => p.ParticipantInfo)
                .SingleOrDefault(activ => activ.ActivityId == activityId);
            int someUser = (int)HttpContext.Session.GetInt32("UserId");
            ViewBag.User = someUser;
            return View(retrievedActivity);
        }

        [HttpGet("delete/{activityId}")]
        public IActionResult Delete(int activityId)
        {
            Act retrievedActivity = dbContext.Acts.SingleOrDefault(activity => activity.ActivityId == activityId);
            dbContext.Acts.Remove(retrievedActivity);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("join/{activityId}")]
        public IActionResult RSVP(int activityId)
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            int someUserId = (int)thisUserId;
            JoinedActivity newParticipant = new JoinedActivity()
            {
                ActivityId = activityId,
                UserId = someUserId,
            };
            dbContext.JoinedActivities.Add(newParticipant);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("leave/{activityId}")]
        public IActionResult UnRSVP(int activityId)
        {
            JoinedActivity retrievedParticipant = dbContext.JoinedActivities.SingleOrDefault(p => p.ActivityId == activityId);
            dbContext.JoinedActivities.Remove(retrievedParticipant);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
