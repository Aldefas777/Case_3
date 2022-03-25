using ClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Interfaces
{
    public interface ICostumerRepository
    {
        List<Costumers> GetUsers(string search);
        void AddUsers(int? id, string names, string surname, string SecondName, string Aboniment);
        void UpdateUser(int? Id, string names, string surname, string SecondName, string Aboniment);
        IEnumerable<Costumers> DeleteUser(int? id);
    }
}
