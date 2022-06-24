using Microsoft.Data.Sqlite;
using SQLitePCL;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClassLibrary.Interfaces;
using System.Data.SqlClient;

namespace ClassLibrary.Classes
{
    public class CustumerRepository : ICustumerRepository 
    {
        
        BaseRepository baseRepository = new BaseRepository();
        public void AddCustumer(CustumerModel model)
        {
                using (var db = baseRepository.GetConnection())
                {
                    db.Open();
                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = db;

                    if (model.Name != null)
                    {
                        insertCommand.CommandText = "INSERT INTO Costumers VALUES (@Name, @Surname, @SecondName, @Date, @Aboniment, @DateAboniment);";
                        insertCommand.Parameters.AddWithValue("@Name", model.Name);
                        insertCommand.Parameters.AddWithValue("@Surname", model.Surname);
                        insertCommand.Parameters.AddWithValue("@SecondName", model.SecondName);
                        insertCommand.Parameters.AddWithValue("@Aboniment", model.Aboniment);
                        insertCommand.Parameters.AddWithValue("@Date", DateTime.Today.ToString());
                        insertCommand.Parameters.AddWithValue("@DateAboniment", DateTime.Today.AddMonths(1).ToString());

                    insertCommand.ExecuteReader();
                    }


                    db.Close();
                }
            
        }
        public IEnumerable<Custumers> DeleteCustumer(int id)
        {
            using (var db = baseRepository.GetConnection())
            {
                var result = db.Query<Custumers>($"DELETE FROM Costumers WHERE id = {id}");

                return result;
            }
        }

        public List<Custumers> GetCustumers(string search)
        {

            using (var db = baseRepository.GetConnection())
            {
                if (search != null)
                {
                    var result = db.Query<Custumers>($"SELECT * FROM Costumers WHERE Surname = N'{search}' OR Name = N'{search}' OR SecondName = N'{search}' OR Aboniment = N'{search}'").ToList();
                    return result;
                }
                else
                {
                    var result = db.Query<Custumers>("SELECT * FROM Costumers").ToList();
                    return result;
                }


            }
        }

        public IEnumerable<Custumers> GetCustumer(int id)
        {
            using (var db = baseRepository.GetConnection())
            {
                var result = db.Query<Custumers>($"SELECT * FROM Costumers WHERE id = {id}").ToList();

                return result;
            }
        }

        public void UpdateCustumer(int Id, CustumerModel model)
        {
            try
            {
                using (var db = baseRepository.GetConnection())
                {
                    db.Open();
                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = db;

                    if (model.Name != null)
                    {
                        insertCommand.CommandText = "UPDATE Costumers SET Name = (@Name), Surname = (@Surname), SecondName = (@SecondName), Aboniment = (@Aboniment) WHERE Id = (@Id);";
                        insertCommand.Parameters.AddWithValue("@Id", Convert.ToInt32(Id));
                        insertCommand.Parameters.AddWithValue("@Name", model.Name);
                        insertCommand.Parameters.AddWithValue("@Surname", model.Surname);
                        insertCommand.Parameters.AddWithValue("@SecondName", model.SecondName);
                        insertCommand.Parameters.AddWithValue("@Aboniment", model.Aboniment);
                        insertCommand.ExecuteReader();
                    }


                    db.Close();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
