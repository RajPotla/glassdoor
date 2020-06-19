using Glassdoor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Glassdoor.Controllers
{
    public class HomeController : Controller
    {

        private GlassdoorDBEntities database = new GlassdoorDBEntities();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection data)
        {
            string email = data["inputEmailAddress"];
            string password = data["inputPassword"];
            
            User x = new User();
            x.Email = email;
            x.Password = password;

            if (ModelState.IsValid)
            {
                if (database.Users.Find() != null)
                {

                    
                    return View("Contact");

                }
                else
                {

                    return View("About");

                }

            }
            else
            {

                return View("Error");

            }
        }

    }
}