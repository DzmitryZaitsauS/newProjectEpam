using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProjectEpam.Models;

namespace NewProjectEpam.Controllers
{
   [Authorize(Users = "dmitry_zajcew@mail.ru")]
    public class UserController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        [HttpGet]
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Logins).Include(u => u.Roles).ToList();
            return View(users);
        }
        
        [HttpGet]
       [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult Edit(int id)
        {
            ApplicationUser user = db.Users.Find(id);
            SelectList departments = new SelectList(db.Users, "Id", "Name", user.Logins);
            ViewBag.Departments = departments;
            SelectList roles = new SelectList(db.Roles, "Id", "Name", user.Roles);
            ViewBag.Roles = roles;

            return View(user);
        }

        [HttpPost]
      [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            SelectList departments = new SelectList(db.Users, "Id", "Name");
            ViewBag.Departments = departments;
            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;

            return View(user);
        }
        [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult Delete(int id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}