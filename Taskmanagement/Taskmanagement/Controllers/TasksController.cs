using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Taskmanagement.Models;

namespace Taskmanagement.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        TaskManagementEntities4 db = new TaskManagementEntities4();
        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display()
        {
            List<Task> Employees = db.Tasks.ToList();
            return View(Employees);
        }

        public ActionResult AdminDisplay()
        {
            List<Task> Employees = db.Tasks.ToList();
            return View(Employees);
        }

        [Authorize(Roles ="User , Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task E1)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                db.Tasks.Add(E1);
                db.SaveChanges();
                return RedirectToAction("Display");
            }
        }

        [Authorize(Roles ="User")]
        public ActionResult Update(int id)
        {
            Task s2 = db.Tasks.Find(id);
            return View(s2);
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public ActionResult Update(Task s3)
        {
            db.Entry<Task>(s3).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Display");
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int id)
        {
            Task s4 = db.Tasks.Find(id);
            db.Tasks.Remove(s4);
            db.SaveChanges();
            return RedirectToAction("AdminDisplay");
        }
    }
}