using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EpamTest2.Models
{
    public class DataInput
    {
        [Required(ErrorMessage = "Person last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Person first name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Person birth year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Person telephone number is required")]
        public string Telephone { get; set; }
    }
}