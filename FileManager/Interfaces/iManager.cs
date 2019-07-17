using System.Collections.Generic;
using FileManager.Models;

namespace FileManager.Interfaces
{
    public interface iManager
    {
        void AddToList(Person newPerson);

        void SortListByLastName();

        void SortListByBirth();

        List<Person> GetList();

        bool RemoveFromList(int PersonId);

        List<Person> SearchInList(string Key);

        void SaveFile();

        void ReadFile();
    }
}
