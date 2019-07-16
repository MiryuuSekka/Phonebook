using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpamTest2.Models;
using BLL;

namespace EpamTest2.Controllers
{
    public class LibController : Controller
    {
        Data Book;

        public LibController()
        {
            Book = new Data();
        }

        public ActionResult TelephoneBook()
        {
            
            var Data = Book.GetList();
            return View(Data);
        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(DataInput obj)
        {
            bool Errors = false;
            if (obj.FirstName.Length > 20)
            {
                ViewBag.Error = TempData["Too Long First Name"];
                Errors = true;
            }

            if (obj.LastName.Length > 20)
            {
                ViewBag.Error = TempData["Too Long Last Name"];
                Errors = true;
            }

            if ((obj.Year < 1900) || (obj.Year > DateTime.Now.Year))
            {
                ViewBag.Error = TempData["Invalid year"];
                Errors = true;
            }
            
            if (!Errors)
            {
                Book.AddPersonToBook(obj.FirstName, obj.LastName, obj.Year, obj.Telephone);
                TempData["PersonData"] = obj;
            }
            return View(obj);
        }

    }
}