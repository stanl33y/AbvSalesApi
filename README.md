# Ambev Developer Evaluation

This project is a .NET 8 application that provides a web API with user and sales management features. It uses a clean architecture approach with domain-driven design principles.

## Prerequisites

To run this project, you'll need:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) (only required for local development)

## Technology Stack

- .NET 8
- PostgreSQL 13 (Main Database)
- MongoDB 8.0 (NoSQL Database)
- Redis 7.4.1 (Cache)
- Docker & Docker Compose

## Running the Application

### Using Docker Compose (Recommended)

1. Clone the repository:
```bash
git clone [repository-url]
cd [repository-name]
```

2. Start the application and its dependencies using Docker Compose:
```bash
docker-compose up -d
```

This command will:
- Build the .NET application
- Start PostgreSQL database
- Start MongoDB instance
- Start Redis cache
- Configure all necessary networking between services

### Service Endpoints

After starting the application, the following services will be available:

- **Web API**: 
  - HTTP: http://localhost:8000
  - HTTPS: https://localhost:8081
- **PostgreSQL**: localhost:5432
  - Database: developer_evaluation
  - Username: developer
  - Password: ev@luAt10n
- **MongoDB**: localhost:27017
  - Username: developer
  - Password: ev@luAt10n
- **Redis**: localhost:6379
  - Password: ev@luAt10n

## Development Setup

For local development without Docker:

1. Install the .NET 8 SDK
2. Restore dependencies:
```bash
dotnet restore
```

3. Update the connection strings in `appsettings.Development.json` to point to your local services

4. Run the application:
```bash
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj
```

## Project Structure

The solution follows a clean architecture approach with the following projects:

- **WebApi**: HTTP API endpoints and controllers
- **Application**: Application services and command handlers
- **Domain**: Core business logic and entities
- **ORM**: Data access layer with Entity Framework Core and MongoDB service implementations
- **IoC**: Dependency injection configuration

## Running Tests

To run the automated tests:

```bash
dotnet test
```

For test coverage report:

```bash
# On Windows
coverage-report.bat

# On Linux/macOS
./coverage-report.sh
```

## Contributing

1. Create a new branch for your feature
2. Make your changes
3. Run the tests
4. Submit a pull request
