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
        public ActionResult Index()
        {
            var BookCopy = BookRepository.WorkAtBook.GetList();

            return View(BookCopy);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person obj)
        {
            BookRepository.WorkAtBook.AddToList(obj);
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Person obj)
        {
            BookRepository.WorkAtBook.RemoveFromList(obj);
            return View(BookRepository.WorkAtBook.GetList());
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string Key)
        {
            var FindedList = BookRepository.WorkAtBook.SearchInList(Key);
            return View(FindedList);
        }
        
        public ActionResult ViewPhonebook()
        {
            return View();
        }
    }
}