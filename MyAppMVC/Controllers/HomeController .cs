using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAppMVC.Models;
using MyAppMVC.ViewModels;
using MyAppMVC.ViewModels.HomeViewModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MyAppMVC.Filters;

namespace MyAppMVC.Controllers
{
    [LogActionFilter] //filter to log all actions
    public class HomeController : Controller
    {
        static int _userId = 1;
        static int _consultationId = 1;
        private static readonly List<User> _users = new();
        private static readonly List<Consultation> _consultations = new();
        private static readonly List<string> _subjects = new List<string> { "JavaScript", "C#", "Java", "Python", "Основи Програмування" };

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [UniqueUsersFilter]
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            Console.WriteLine(user.Login);
            if (ModelState.IsValid)
            {
                user.Id = _userId;
                Console.WriteLine($"user.Id ---- {user.Id}");
                _users.Add(user);
                Response.Cookies.Append("userId", _userId.ToString());
                _userId++;

                return View("Index");
            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    for (int i = 0; i < ModelState[key].Errors.Count; i++)
                    {
                        var error = ModelState[key].Errors[i];
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }

                ViewBag.Subjects = new SelectList(_subjects);
                return View("SignUp", user);
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Subjects = new SelectList(_subjects);

            return View();
        }

        [HttpPost]
        public ActionResult CreateConsultation(Consultation consultation)
        {
            if (ModelState.IsValid )
            {
                if (consultation.Subject == "Основи Програмування" && consultation.DateOfConsultation.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("DateOfConsultation", "Консультація щодо 'Основи Програмування' не може проходити в понеділок.");
                    ViewBag.Subjects = new SelectList(_subjects);
                    return View("Index", consultation);
                }

                consultation.Id = _consultationId;
                Console.WriteLine($"{consultation.Id}, {consultation.Name}, {consultation.Email}, {consultation.DateOfConsultation}, {consultation.Subject}");
                _consultations.Add(consultation);
                _consultationId++;

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            else {
                foreach (var key in ModelState.Keys)
                {
                    for (int i = 0; i < ModelState[key].Errors.Count; i++)
                    {
                        var error = ModelState[key].Errors[i];
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }

                ViewBag.Subjects = new SelectList(_subjects);
                return View("Index", consultation);
            }

        }

        public ActionResult ShowConsultations(ShowStyles showStyle)
        {
            Console.WriteLine($"old style: {showStyle}");
            ShowConsultationsViewModel showConsultationsViewModel = new(_consultations, showStyle);
            return View(showConsultationsViewModel);
        }


        [HttpPost]
        public ActionResult ToggleView(string ShowStyle)
        {
            Console.WriteLine($"old style: {ShowStyle}");
            ShowStyles newStyle = ShowStyle == ShowStyles.List.ToString() ? ShowStyles.Table : ShowStyles.List;
            Console.WriteLine($"new style: {newStyle}");
            ShowConsultationsViewModel showConsultationsViewModel = new(_consultations, newStyle);
            return View("ShowConsultations", showConsultationsViewModel);
        }


    }
}