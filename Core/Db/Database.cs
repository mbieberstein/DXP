using Core.Cfg;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Db
{
    public class Database : IDisposable
    {
        private SqlConnection connection;

        public Database() {

            var connectionString = Configuration.ConnectionString;

            connection = new SqlConnection(connectionString);

            connection.Open();

        }

        public void CreateTable(string name)
        {
            var sql = $"CREATE TABLE {name}" +
            $"(id uniqueidentifier CONSTRAINT PKey_{name} PRIMARY KEY," +
            "name NVARCHAR(50) NOT NULL";

            ExecuteNonQuery(sql);
        }

        public void DeleteTable(string name)
        {
            var sql = $"DROP TABLE {name}";

            ExecuteNonQuery(sql);
        }

        public void AddTextField(string table, string name)
        {
            AddField(table, name, "nvarchar(50)");
        }

        public void AddBigTextField(string table, string name)
        {
            AddField(table, name, "nvarchar(500)");
        }

        public void AddIntField(string table, string name)
        {
            AddField(table, name, "int");
        }

        public void AddDateField(string table, string name)
        {
            AddField(table, name, "datetime");
        }

        public void AddField(string table, string name, string type) 
        { 
            var sql = $"ALTER TABLE {table} add {name} {type}";

            ExecuteNonQuery(sql);
        }

        private void ExecuteNonQuery(string sql)
        {
            using(SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;

                command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            try { connection.Close(); } catch { }
        }
    }
}
