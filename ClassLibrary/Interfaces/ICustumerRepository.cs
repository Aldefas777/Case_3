using ClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Interfaces
{
    public interface ICustumerRepository
    {
        List<Custumers> GetUsers(string search);
        IEnumerable<Custumers> GetPerson(int id);

        void AddUsers(int Id, string names, string surname, string SecondName, string Aboniment);
        void UpdateUser(int Id, string names, string surname, string SecondName, string Aboniment);
        IEnumerable<Custumers> DeleteUser(int id);
    }
}
