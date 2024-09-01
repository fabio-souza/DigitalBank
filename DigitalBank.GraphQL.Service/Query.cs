using Microsoft.EntityFrameworkCore;
using DigitalBank.DataContext.MySql;
using DigitalBank.EntityModels;

namespace DigitalBank.GraphQL.Service;
public class Query
{
  public string GetGreeting() => "Hello, World!";

  public IQueryable<Client> GetClients(DigitalBankContext db) => db.Clients.Include(c => c.Accounts);

}