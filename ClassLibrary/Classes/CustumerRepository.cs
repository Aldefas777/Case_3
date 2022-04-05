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


namespace ClassLibrary.Classes
{
    public class CustumerRepository : ICustumerRepository 
    {
        BaseRepository baseRepository = new BaseRepository();
        public void AddUsers(int Id, string names, string surname, string SecondName, string Aboniment)
        {

            using (var db = baseRepository.GetConnection())
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                if (names != null)
                {
                    insertCommand.CommandText = "INSERT INTO Costumers VALUES (@Id, @Name, @Surname, @SecondName, @Date, @Aboniment);";
                    insertCommand.Parameters.AddWithValue("@Id", Convert.ToInt32(Id));
                    insertCommand.Parameters.AddWithValue("@Name", names);
                    insertCommand.Parameters.AddWithValue("@Surname", surname);
                    insertCommand.Parameters.AddWithValue("@SecondName", SecondName);
                    insertCommand.Parameters.AddWithValue("@Aboniment", Aboniment);
                    insertCommand.Parameters.AddWithValue("@Date", DateTime.Today.ToString());
                    insertCommand.ExecuteReader();
                }


                db.Close();
            }
        }
        public IEnumerable<Custumers> DeleteUser(int id)
        {
            using (var db = baseRepository.GetConnection())
            {
                var result = db.Query<Custumers>($"DELETE FROM [Costumers] WHERE id = {id}");

                return result;
            }
        }

        public List<Custumers> GetUsers(string search)
        {

            using (var db = baseRepository.GetConnection())
            {
                if (search != null)
                {
                    var result = db.Query<Custumers>($"SELECT * FROM [Costumers] WHERE Surname = '{search}' OR Name = '{search}' OR SecondName = '{search}' OR Aboniment = '{search}'").ToList();
                    return result;
                }
                else
                {
                    var result = db.Query<Custumers>("SELECT * FROM Costumers").ToList();
                    return result;
                }


            }
        }

        public IEnumerable<Custumers> GetPerson(int id)
        {
            using (var db = baseRepository.GetConnection())
            {
                var result = db.Query<Custumers>($"SELECT * FROM [Costumers] WHERE id = {id}").ToList();

                return result;
            }
        }

        public void UpdateUser(int Id, string names, string surname, string SecondName, string Aboniment)
        {
            using (var db = baseRepository.GetConnection())
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                if (names != null)
                {
                    insertCommand.CommandText = "UPDATE [Costumers] SET Name = (@Name), Surname = (@Surname), SecondName = (@SecondName), Aboniment = (@Aboniment) WHERE Id = (@Id);";
                    insertCommand.Parameters.AddWithValue("@Id", Convert.ToInt32(Id));
                    insertCommand.Parameters.AddWithValue("@Name", names);
                    insertCommand.Parameters.AddWithValue("@Surname", surname);
                    insertCommand.Parameters.AddWithValue("@SecondName", SecondName);
                    insertCommand.Parameters.AddWithValue("@Aboniment", Aboniment);
                    insertCommand.ExecuteReader();
                }


                db.Close();
            }
        }
    }
}
