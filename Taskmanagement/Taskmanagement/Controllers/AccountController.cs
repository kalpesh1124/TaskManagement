using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taskmanagement.Models;
using System.Web.Security;
using Microsoft.Ajax.Utilities;

namespace Taskmanagement.Controllers
{
    //[AllowAnonymous]
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.user model) 
        {
            
            using (var context = new TaskManagementEntities2())
            {
                bool isValid =  context.Userinfoes.Any(x=>x.UserName == model.UserName && x.Passworord == model.Passworord);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName,false);
                        return RedirectToAction("Create", "Tasks");
                }
                ModelState.AddModelError("", "Invalid Username And Password!!");
                return View();
            }
            
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Userinfo model)
        {
            using(var context = new TaskManagementEntities2())
            {
                context.Userinfoes.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}