using Microsoft.AspNetCore.Mvc;
using MemuTechAPI.Models.Infrastructure;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace MemuTechAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    // private readonly IDatabaseAccessor db;
    // public CustomersController(IDatabaseAccessor db)
    // {
    //     this.db = db;
    // }

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        using (var cl = new SqliteConnection(@"Data Source=.\data\Memu.db"))
        {
            string query = "SELECT Id, Uuid, Tipo, Codice, Titolo, RagioneSociale FROM EB_ClientiFornitori";
            var customers = cl.Query<Customer>(query).ToList();
            return customers;
        }        
    }

    [HttpPost]
    public int PostCustomers(Customer customer)
    {
        int newCustomers = 0;
        using (var cl = new SqliteConnection(@"Data Source=.\data\Memu.db")) 
        {
            string query = "INSERT INTO EB_ClientiFornitori VALUES (@Id, @Uuid, @Tipo, @Codice, @Titolo, @RagioneSociale)";
            newCustomers = cl.Execute(query);
        }
        return newCustomers;
    }

    [HttpPut]
    public int PutCustomers(Customer customer)
    {
        int updCustomers = 0;
        using (var cl = new SqliteConnection(@"Data Source=.\data\Memu.db"))
        {
            string query = "UPDATE Tipo=@Tipo, Codice=@Codice, Titolo=@Titolo, RagioneSociale=@RagioneSociale FROM EB_ClientiFornitori WHERE (Id = @Id)";
            updCustomers = cl.Execute(query);
        }
        return updCustomers;
    }

}