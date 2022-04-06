using ClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Interfaces
{
    public interface ICustumerRepository
    {
        List<Custumers> GetCustumers(string search);
        IEnumerable<Custumers> GetCustumer(int id);

        void AddCustumer(int Id, string names, string surname, string SecondName, string Aboniment);
        void UpdateCustumer(int Id, string names, string surname, string SecondName, string Aboniment);
        IEnumerable<Custumers> DeleteCustumer(int id);
    }
}
