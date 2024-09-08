FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy project files
COPY DigitalBank.GraphQL/*.csproj ./DigitalBank.GraphQL/
# Restore as distinct layers
RUN dotnet restore DigitalBank.GraphQL/DigitalBank.GraphQL.csproj

# Copy the rest of the application
COPY . ./
# Build and publish a release
RUN dotnet publish DigitalBank.GraphQL/DigitalBank.GraphQL.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

# Expose the port on which the app will run
EXPOSE 8080

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "DigitalBank.GraphQL.dll"]