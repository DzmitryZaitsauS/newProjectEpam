using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewProjectEpam.Models.myTable;
using NewProjectEpam.Models;

namespace NewProjectEpam.Controllers
{
    
    public class HomeController : Controller
    {
        Repository repozit = new Repository();
public ActionResult Index()
        {
           
            return View(repozit.SelectNews());
        }


        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Chat()
        {
            ViewBag.Message = "This chat.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Your Admin page.";

            return View();
        }

        [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult AdminCategor()
        {
            ViewBag.Message = "Your Category page.";
           /* List<TableCategories> Categories = new List<TableCategories>()
            {
           new  TableCategories(){Typess="- Новости IT"},
             new  TableCategories(){Typess="- Новости мира"},
               new  TableCategories(){Typess="- Новости Белоруси"}

            };*/

            return View(repozit.SelectCategories());
        }

        [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult AdminRole()
        {
            ViewBag.Message = "Your Category page.";

            return View();
        }
             [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult AddCategories(string typess)
        {
            ViewBag.Title = "Добавление категории";
           repozit.GreateCategories(typess);
           return RedirectToAction("AdminCategor", "Home");
        }
             [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult DeleteCategories(string typess)
        {
            ViewBag.Title = "Удаление категории";
            repozit.DeleteCategories(typess);
            return RedirectToAction("AdminCategor", "Home");
        }
             [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult DeleteMyNews(int id_news)
        {
            ViewBag.Title = "Удаление новости";
            repozit.DeleteNews(id_news);
            return RedirectToAction("Index", "Home");
        }
             [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult UpdateNews(int id_news)
        {
            return View(repozit.UpdateNews(id_news));
        }
        [Authorize]
        public ActionResult AddComment(string comment, int id_news)
        {
            ViewBag.Title = "Добавление коментария";
            repozit.AddComments(comment, id_news);
            return RedirectToAction("Index", "Home");
        
        }
             [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult DeleteComments(int id_comment )
        {
            ViewBag.Title = "Добавление коментария";
            repozit.DeleteComments(id_comment);
            return RedirectToAction("Index", "Home");

        }
             [Authorize(Users = "dmitry_zajcew@mail.ru")]
        public ActionResult SaveNews(int id_news, string name_news, string typess, string content, string img)
        {
            ViewBag.Title = "Обновление новости";
            repozit.SaveNews(id_news,  name_news,  typess,  content,  img);
            return RedirectToAction("Index", "Home");

        }
        [Authorize]
        public ActionResult PolOcNews(int id_news)
        {
            ViewBag.Title = "+ новости";
            repozit.PolOcNews(id_news);
            return RedirectToAction("Index", "Home");

        }
        [Authorize]
        public ActionResult OtrOcNews(int id_news)
        {
            ViewBag.Title = "- новости";
            repozit.OtrOcNews(id_news);
            return RedirectToAction("Index", "Home");

        }
    [Authorize]
        public ActionResult PolOcComment(int id_comment)
        {
            ViewBag.Title = "+ новости";
            repozit.PolOcComment(id_comment);
            return RedirectToAction("Index", "Home");

        }
        [Authorize]
        public ActionResult OtrOcComment(int id_comment)
        {
            ViewBag.Title = "- новости";
            repozit.OtrOcComment(id_comment);
            return RedirectToAction("Index", "Home");

        }
        
    }
}