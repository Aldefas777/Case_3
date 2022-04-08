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

        void AddCustumer(CustumerModel model);
        void UpdateCustumer(int Id, CustumerModel model);
        IEnumerable<Custumers> DeleteCustumer(int id);
    }
}
