using DigitalBank.GraphQL.Service; // Query
using DigitalBank.DataContext.MySql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDigitalBankContext();
builder.Services
  .AddGraphQLServer()
  .RegisterDbContext<DigitalBankContext>()
  .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => "Navigate to: http://localhost:8080/graphql");

app.MapGraphQL();

app.Run();
