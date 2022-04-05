using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Classes
{
    public class BaseRepository
    {
        public SqliteConnection GetConnection()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            return new SqliteConnection(connectionString);
        }
    }
}
