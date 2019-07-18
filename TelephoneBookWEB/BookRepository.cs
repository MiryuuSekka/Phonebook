using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FileManager;
using FileManager.Models;
using System.Web.Hosting;

namespace TelephoneBookWEB
{
    internal static class BookRepository
    {
        internal static Manager WorkAtBook = new Manager(HostingEnvironment.MapPath(@"~/Note.xml"));
        
    }
}