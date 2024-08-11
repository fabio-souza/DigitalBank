FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy project files
COPY DigitalBank.GraphQL.Service/*.csproj ./DigitalBank.GraphQL.Service/
# Restore as distinct layers
RUN dotnet restore DigitalBank.GraphQL.Service/DigitalBank.GraphQL.Service.csproj

# Copy the rest of the application
COPY . ./
# Build and publish a release
RUN dotnet publish DigitalBank.GraphQL.Service/DigitalBank.GraphQL.Service.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

# Expose the port on which the app will run
EXPOSE 8080

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "DigitalBank.GraphQL.Service.dll"]