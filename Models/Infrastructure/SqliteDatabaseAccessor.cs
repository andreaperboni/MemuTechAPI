using System.Data;

namespace MemuTechAPI.Models.Infrastructure
{
    public class SqliteDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(string query)
        {
            throw new NotImplementedException();
        }
    }
}