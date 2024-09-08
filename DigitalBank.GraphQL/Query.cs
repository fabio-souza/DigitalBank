using DigitalBank.Domain.Entities;
using DigitalBank.Domain.Interfaces;

namespace DigitalBank.GraphQL;
public class Query
{
  public async Task<List<Client>> GetClients(IClientRepository clientRepository) => await clientRepository.ListAsync();
}