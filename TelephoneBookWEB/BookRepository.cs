using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FileManager;
using FileManager.Models;

namespace TelephoneBookWEB
{
    public class BookRepository
    {
        private Manager WorkAtBook;
        public BookRepository()
        {
            WorkAtBook = new Manager();
            WorkAtBook.ReadFile();
        }
        public async Task<List<Person>> GetBook()
        {
            return await Task.Run(() => WorkAtBook.GetList());
        }

        public async Task<Person> GetPerson(int id)
        {
            return await Task.Run(() => WorkAtBook.GetList().FirstOrDefault(x => x.Id == id));
        }

        public async void AddPerson(Person NewPerson)
        {
            await Task.Run(() => WorkAtBook.AddToList(NewPerson));
        }

        public async void RemovePerson(Person SelectedPerson)
        {
            await Task.Run(() => WorkAtBook.RemoveFromList(SelectedPerson));
        }

        public async void SortByBirth()
        {
            await Task.Run(() => WorkAtBook.SortListByBirth());
        }

        public async void SortByName()
        {
            await Task.Run(() => WorkAtBook.SortListByLastName());
        }

        public async Task<List<Person>> Search(string Key)
        {
            return await Task.Run(() => WorkAtBook.SearchInList(Key));
        }
    }
}