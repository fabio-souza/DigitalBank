using DigitalBank.GraphQL; // Query
using DigitalBank.Infrastructure.Extensions;
using DigitalBank.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDigitalBankContext();

builder.Services.AddDigitalBankRepositories();

builder.Services
  .AddGraphQLServer()
  .RegisterService<IClientRepository>(ServiceKind.Synchronized)
  .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => "Navigate to: http://localhost:8080/graphql");

app.MapGraphQL();

app.Run();
