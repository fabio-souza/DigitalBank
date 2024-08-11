using DigitalBank.GraphQL.Service; // Query

var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddGraphQLServer()
  .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => "Navigate to: http://localhost:8080/graphql");

app.MapGraphQL();

app.Run();
