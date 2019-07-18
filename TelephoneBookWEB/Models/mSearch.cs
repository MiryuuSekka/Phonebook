using System.ComponentModel.DataAnnotations;
using FileManager.Models;
using System.Collections.Generic;

namespace TelephoneBookWEB.Models
{
    public class mSearch
    {
        public string Keyword { get; set; }

        public List<Person> FindedList { get; set; }
    }
}