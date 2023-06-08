using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace MemuTechAPI.Models.Infrastructure
{
    public class SqliteDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(string query)
        {
            throw new Exception();
        }

        public void Prova()
        {
            var cl = new SqliteConnection("");
            var rows = cl.Query("select 1 A, 2 B union all select 3, 4").AsList();
            
        }
    }

    
}