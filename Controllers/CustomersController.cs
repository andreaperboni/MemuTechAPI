using Microsoft.AspNetCore.Mvc;
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
        using (var cl = new SqliteConnection(@"Data Source=./data/Memu.db"))
        {
            string query = "SELECT Id, Codice as CodClient, RagioneSociale as NomeClient, 'Verona' as LocClient, '045123456' as TelClient, 0 as DisactiveClient FROM EB_ClientiFornitori";
            var customers = cl.Query<Customer>(query).ToList();
            return customers;
        }        
    }

    [HttpGet("{id}")]
    public Customer GetCustomer(string id)
    {
        using (var cl = new SqliteConnection(@"Data Source=./data/Memu.db"))
        {
            string query = "SELECT Id, Codice as CodClient, RagioneSociale as NomeClient, 'Verona' as LocClient, '045123456' as TelClient, 0 as DisactiveClient FROM EB_ClientiFornitori WHERE Codice = '" + id + "'";
            var customer = cl.Query<Customer>(query).SingleOrDefault();
            return customer;
        }        
    }

    [HttpPost]
    public int PostCustomers(Customer customer)
    {
        int newCustomers = 0;
        using (var cl = new SqliteConnection(@"Data Source=.\data\Memu.db")) 
        {
            //var parameters = new SqliteParameterCollection();
            //parameters.Add(new SqliteParameter("Id",customer.Id));
            //string query = "INSERT INTO EB_ClientiFornitori VALUES (@Id, @CodClient, @NomeClient, @LocClient, @TelClient, 0)";
            //newCustomers = cl.Execute(query, parameters);
        }
        return newCustomers;
    }

    [HttpPut]
    public int PutCustomers(Customer customer)
    {
        int updCustomers = 0;
        using (var cl = new SqliteConnection(@"Data Source=.\data\Memu.db"))
        {
            //string query = "UPDATE Tipo=@Tipo, Codice=@Codice, Titolo=@Titolo, RagioneSociale=@RagioneSociale FROM EB_ClientiFornitori WHERE (Id = @Id)";
            //updCustomers = cl.Execute(query);
        }
        return updCustomers;
    }

}