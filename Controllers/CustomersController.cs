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
            string query = "SELECT Id, Codice as CodClient, RagioneSociale as NomeClient, Localita as LocClient, PartitaIVA as TelClient, 0 as DisactiveClient FROM EB_ClientiFornitori";
            var customers = cl.Query<Customer>(query).ToList();
            return customers;
        }        
    }

    [HttpGet("{id}")]
    public Customer GetCustomer(string id)
    {
        using (var cl = new SqliteConnection(@"Data Source=./data/Memu.db"))
        {
            string query = "SELECT Id, Codice as CodClient, RagioneSociale as NomeClient, Localita as LocClient, PartitaIVA as TelClient, 0 as DisactiveClient FROM EB_ClientiFornitori WHERE Codice = '" + id + "'";
            var customer = cl.Query<Customer>(query).SingleOrDefault();
            return customer;
        }        
    }

    [HttpPost]
    public string PostCustomers(Customer customer)
    {
        var newCustomers = 0;
        using (var cl = new SqliteConnection(@"Data Source=./data/Memu.db")) 
        {
            //var parameters = new SqliteParameterCollection();
            //parameters.Add(new SqliteParameter("Id",customer.Id));
            //parameters.Add(new SqliteParameter("CodClient",customer.CodClient));
            //parameters.Add(new SqliteParameter("NomeClient",customer.NomeClient));
            //parameters.Add(new SqliteParameter("LocClient",customer.LocClient));
            //parameters.Add(new SqliteParameter("TelClient",customer.TelClient));
            //string query = $"INSERT INTO [EB_ClientiFornitori] (Codice, RagioneSociale, Localita, PartitaIVA) VALUES ('{customer.CodClient}', '{customer.NomeClient}', '{customer.LocClient}', '{customer.TelClient}')";
            //newCustomers = cl.Execute(query);
        }
        return $"Oggetto ottenuto: Codice: {customer.CodClient}, RagioneSociale: {customer.NomeClient}, Località: {customer.LocClient}."; //newCustomers;
    }

    [HttpPut("{id}")]
    public int PutCustomers(string id, Customer customer)
    {
        var updCustomers = 0;
        using (var cl = new SqliteConnection(@"Data Source=./data/Memu.db"))
        {
            string query = $"UPDATE [EB_ClientiFornitori] SET RagioneSociale='{customer.NomeClient}', Localita='{customer.LocClient}' WHERE Codice='{id}'";
            updCustomers = cl.Execute(query);
        }
        return updCustomers;
    }

}