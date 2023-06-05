using Microsoft.AspNetCore.Mvc;
using MemuTechAPI.Models.Infrastructure;
using System.Data;

namespace MemuTechAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IDatabaseAccessor db;
    public CustomersController(IDatabaseAccessor db)
    {
        this.db = db;
    }

    public List<Customers> GetCustomers()
    {
            string query = "SELECT * FROM EB_ClientiFornitori";
            DataSet dataset = db.Query(query);
            return new List<Customers>();
    }
}