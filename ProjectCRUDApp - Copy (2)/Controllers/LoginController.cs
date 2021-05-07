using Microsoft.AspNetCore.Mvc;
using ProjectAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUDApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(User user)
        {
            if (user.UserName == "" && user.Password=="")
            {

            }
        
            return View("LogInSuccess", user); //page to view and where the data is taken to
        }
    }
}
