using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProjectEpam.Models;

namespace NewProjectEpam.Controllers
{
    public class ZakazNewsController : Controller
    {

        Repository repoz = new Repository();
        //
        // GET: /ZakazNews/
        [Authorize]
        public ActionResult ZakazNews()
        {
            return View(repoz.SelectZakazNews());
        }
        [Authorize]
        public ActionResult AddZakazNews(string name_news)
        {
            ViewBag.Title = "Предложить новость";
           repoz.GreateZakazNews(name_news);
           return RedirectToAction("ZakazNews", "ZakazNews");
        }
             [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult DeleteZakaz(int id_zakaz)
        {
            ViewBag.Title = "Удалить";
            repoz.DeleteZakazNews(id_zakaz);
            return RedirectToAction("ZakazNews", "ZakazNews");
        }
        [Authorize]
        public ActionResult PolOzZakaz(int id_zakaz)
        {
            ViewBag.Title = "+ Заказ";
            repoz.PolOcZakaz(id_zakaz);
            return RedirectToAction("ZakazNews", "ZakazNews");
        }
        [Authorize]
        public ActionResult OtrOcZakaz(int id_zakaz)
        {
            ViewBag.Title = "- Заказ";
            repoz.OtrOcenZakaz(id_zakaz);
            return RedirectToAction("ZakazNews", "ZakazNews");
           
        }
	}
}