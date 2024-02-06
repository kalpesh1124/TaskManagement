using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taskmanagement.Models;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc.Html;

namespace Taskmanagement.Controllers
{
    //[AllowAnonymous]
    public class AccountController : Controller
    {
        TaskManagementEntities4 db = new TaskManagementEntities4();

      
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.user model) 
        {
            
            using (var context = new TaskManagementEntities4())
            {
                bool isValid =  context.UserInfoes.Any(x=>x.username == model.UserName && x.password == model.Passworord);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName,false);
                    bool isAdmin = context.UserInfoes.Any(x => x.username == model.UserName && x.password == model.Passworord  && x.role=="Admin");
                    
                    if (isAdmin)
                    {
                        return RedirectToAction("AdminDisplay", "Tasks");
                    }
                    else
                    {
                        return RedirectToAction("Create", "Tasks");
                    }
                        
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
        [ValidateAntiForgeryToken]
        public ActionResult Signup(UserInfo model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (model.role != null)
                {
                    
                    db.UserInfoes.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }

            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}