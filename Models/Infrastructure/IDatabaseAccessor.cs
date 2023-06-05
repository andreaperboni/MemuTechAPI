using System.Data;

namespace MemuTechAPI.Models.Infrastructure
{
    public interface IDatabaseAccessor
    {
        DataSet Query(string query);
    }
}
