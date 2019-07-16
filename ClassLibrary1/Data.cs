using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Data
    {
        List<Classes.Person> Book;
        Helper<List<Classes.Person>> WorkWithFile;

        public Data()
        {
            WorkWithFile = new Helper<List<Classes.Person>>();
            Book = new List<Classes.Person>();
            OpenApp();
            WorkWithFile.XmlSerialization(Book);
            Book = WorkWithFile.XmlDeserialization();
        }

        public void OpenApp()
        {
            //read file
            Book.Add(new Classes.Person()
            {
                ID = Book.Count,
                BirthYear = 1994,
                FirstName = "Thomas",
                LastName = "Arclight",
                Telephone = "+4(444)444-44"
            });
        }

        public void CloseApp()
        {
            WorkWithFile.XmlSerialization(Book);
            //save file
        }

        public void AddPersonToBook(string newFirstName, string newLastName, int newYear, string newTelephone)
        {
            Book.Add(new Classes.Person()
            {
                ID = Book.Count,
                FirstName = newFirstName,
                LastName = newLastName,
                BirthYear = newYear,
                Telephone = newTelephone
            });
        }

        public List<Classes.Person> GetList()
        {

            return Book;
        }

        public void SortList()
        {

        }
    }
}
