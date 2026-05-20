# Job Tracker Backend

Clean Architecture .NET Core API for tracking job applications.

## Technologies
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core + SQL Server
- MediatR (CQRS)
- Repository Pattern
- xUnit + Moq
- Swagger

## Projects
- JobTracker.API
- JobTracker.Application
- JobTracker.Domain
- JobTracker.Infrastructure
- JobTracker.Tests

## How to run
1. Clone this repo
2. Update connection string in appsettings.json
3. Package Manager Console: Update-Database -StartupProject JobTracker.API
4. Press F5
5. Open https://localhost:PORT/swagger

## API Documentation
Swagger UI available at: https://localhost:PORT/swagger
All endpoints documented with request/response models.

## UML Class Diagram

```mermaid
classDiagram
    class Company {
        +int Id
        +string Name
        +string Industry
        +string Website
        +List~Job~ Jobs
    }
    class Job {
        +int Id
        +string Title
        +string Description
        +int CompanyId
        +List~Application~ Applications
    }
    class Application {
        +int Id
        +int JobId
        +string Status
        +DateTime AppliedDate
        +string Notes
    }
    Company "1" --> "many" Job : has
    Job "1" --> "many" Application : has
```

## User Flow
User opens app → sees Companies → clicks Company
→ sees Jobs → clicks Job → sees Applications
→ changes Application Status