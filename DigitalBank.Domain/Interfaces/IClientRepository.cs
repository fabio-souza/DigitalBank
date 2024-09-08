using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Interfaces;

public interface IClientRepository
{
    public Task AddAsync(Client client);
    public Task<List<Client>> ListAsync();

    public Task SaveChangesAsync();
}