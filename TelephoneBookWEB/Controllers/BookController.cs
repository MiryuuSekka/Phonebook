using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FileManager.Models;
using System.Web.Hosting;
using TelephoneBookWEB.Models;

namespace TelephoneBookWEB.Controllers
{
    public class BookController : Controller
    {
        public static FileManager.Manager BookManager = new FileManager.Manager(HostingEnvironment.MapPath(@"~/Note.xml"));

        public ActionResult Index()
        {
            var BookCopy = BookManager.GetList();
            BookManager.SaveFile();
            return View(BookCopy);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person obj)
        {
            BookManager.AddToList(obj);
            return View();
        }


        public ActionResult Search()
        {
            var model = new mSearch();
            model.FindedList = BookManager.GetList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(mSearch Key)
        {
            if (Key.Keyword != null)
            {
                Key.FindedList = BookManager.SearchInList(Key.Keyword);
            }
            else
            {
                Key.FindedList = BookManager.GetList();
            }

            
            return View(Key);
        }


        public ActionResult DeletePerson(Person Target)
        {
            BookManager.RemoveFromList(Target);
            var model = new mSearch();
            model.FindedList = BookManager.GetList();


            return View("Search", model);
        }
    }
}