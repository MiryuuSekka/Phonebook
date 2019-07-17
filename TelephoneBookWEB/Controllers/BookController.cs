using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FileManager.Models;

namespace TelephoneBookWEB.Controllers
{
    public class BookController : Controller
    {
        BookRepository Service;
        public BookController()
        {
            Service = new BookRepository();
        }

        public async Task<ActionResult> Index()
        {
            var BookCopy = await Service.GetBook();


            return View(BookCopy);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person obj)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string Key)
        {
            var FindedList = Service.Search(Key);
            return View(FindedList);
        }
        public ActionResult SearchResult(string Key)
        {
            var FindedList = Service.Search(Key);
            return View(FindedList);
        }

        public ActionResult ViewPhonebook()
        {
            return View();
        }
    }
}