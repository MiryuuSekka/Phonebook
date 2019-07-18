using System.ComponentModel.DataAnnotations;
using FileManager.Models;
using System.Collections.Generic;

namespace TelephoneBookWEB.Models
{
    public class modelDelete
    {
        public Person toDelete { get; set; }

        public List<Person> Persons { get; set; }
    }
}