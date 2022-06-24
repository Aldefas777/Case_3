using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ClassLibrary.Interfaces;
using System.Data.SqlClient;

namespace ClassLibrary.Classes
{
    public class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("IdentityConnection");
            return new SqlConnection(connectionString);
        }
    }
}
