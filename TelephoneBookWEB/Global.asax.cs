using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FileManager;
using FileManager.Models;

namespace TelephoneBookWEB
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Controllers.BookController.BookManager.ReadFile();
    }

        protected void Application_Disposed()
        {
            Controllers.BookController.BookManager.SaveFile();
        }
       
    }
}
