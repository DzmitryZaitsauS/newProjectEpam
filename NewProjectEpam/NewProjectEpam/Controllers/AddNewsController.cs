using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProjectEpam.Models;

namespace NewProjectEpam.Controllers
{
    public class AddNewsController : Controller
    {
Repository repoz =new Repository();
        //
        // GET: /AddNews/
        [Authorize]
        public ActionResult AddNews()
        {
            return View();
        }

        [Authorize]
      public ActionResult AddMyNews(string name_news, string content, string img, string typess)
        {
            ViewBag.Title = "Добавить новость";
            repoz.GreateNews(name_news, content, img, typess);
            return RedirectToAction("Index", "Home");
        }  
	}
}