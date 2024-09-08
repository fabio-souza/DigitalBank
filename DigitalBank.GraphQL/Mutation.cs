using DigitalBank.Domain.Entities;
using DigitalBank.Domain.Interfaces;

namespace DigitalBank.GraphQL;

public record AddClientInput(
    string FirstName,
    string LastName
);

public class AddClientPayload
{
    public AddClientPayload(Client client)
    {
        Client = client;
    }

    public Client Client { get; }
}

public class Mutation
{
    public async Task<AddClientPayload> AddClientAsync(
        AddClientInput input, IClientRepository clientRepository)
    {
        Client client = new()
        {
            FirstName = input.FirstName,
            LastName = input.LastName
        };

        await clientRepository.AddAsync(client);
        await clientRepository.SaveChangesAsync();

        return new AddClientPayload(client);
    }
}