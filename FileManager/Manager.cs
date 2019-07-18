using System.Collections.Generic;
using System.Linq;
using FileManager.Helpers;
using FileManager.Models;
using FileManager.Interfaces;

namespace FileManager
{
    public class Manager : iManager
    {
        XmlHelper<List<Person>> xmlHelper;
        List<Person> LocalPhoneBook;

        public Manager(string Path)
        {
            xmlHelper = new XmlHelper<List<Person>>(Path);
            LocalPhoneBook = new List<Person>();
        }

        public List<Person> GetList()
        {
            return LocalPhoneBook;
        }

        public bool RemoveFromList(int PersonId)
        {
            if(PersonId > -1 && PersonId < LocalPhoneBook.Count)
            {
                LocalPhoneBook.RemoveAt(PersonId);
                return true;
            }
            return false;
        }

        public void RemoveFromList(Person SelectedPerson)
        {
            LocalPhoneBook.RemoveAll(c => (c.Phone == SelectedPerson.Phone)&& (c.BirthYear == SelectedPerson.BirthYear)&& (c.LastName== SelectedPerson.LastName)&&(c.FirstName == SelectedPerson.FirstName));
        }

        public void AddToList(Person newPerson)
        {
            LocalPhoneBook.Add(newPerson);
        }

        public List<Person> SearchInList(string Key)
        {
            var Finded = new List<Person>();

            for (int i = 0; i < LocalPhoneBook.Count; i++)
            {
                var result = false;
                if (LocalPhoneBook[i].FirstName.Contains(Key))
                {
                    result = true;
                }
                if (LocalPhoneBook[i].LastName.Contains(Key))
                {
                    result = true;
                }
                if (LocalPhoneBook[i].Phone.Contains(Key))
                {
                    result = true;
                }
                if (result) Finded.Add(LocalPhoneBook[i]);
            }
            return Finded;
        }

        public void SortListByLastName()
        {
            var sortedList = new List<Person>();
            sortedList = LocalPhoneBook.OrderBy(Person => Person.LastName).ToList();
            LocalPhoneBook = sortedList;
        }

        public void SortListByBirth()
        {
            var sortedList = new List<Person>();
            sortedList = LocalPhoneBook.OrderBy(Person => Person.BirthYear).ToList();
            LocalPhoneBook = sortedList;
        }


        public void ReadFile()
        {
            xmlHelper.ReadFile(ref LocalPhoneBook);
        }

        public void SaveFile()
        {
            xmlHelper.WriteFile(LocalPhoneBook);
        }
    }
}
