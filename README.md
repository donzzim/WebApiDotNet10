# WebApiDotNet10 — Video Game Character API

A REST Web API built with **ASP.NET Core (.NET 10)**, **Entity Framework Core** and **SQL Server** to manage video game characters (CRUD).

> 📚 **Study project.** This API was built while following
> [this YouTube tutorial](https://www.youtube.com/watch?v=RwQVRXEs370),
> as a hands-on way to learn the fundamentals of building Web APIs in .NET.

## Tech stack

- .NET 10 / ASP.NET Core Web API (controllers)
- Entity Framework Core 10 + SQL Server
- EF Core migrations with seed data (`HasData`)
- OpenAPI + [Scalar](https://github.com/scalar/scalar) for interactive API docs

## Concepts practiced

- Controllers and attribute routing
- Dependency injection with a service layer (`IVideoGameCharacterService`)
- Async/await end to end (`ToListAsync`, `FirstOrDefaultAsync`, `SaveChangesAsync`)
- DTOs to separate the API contract from the database entity
- Code-first database with migrations and seeding

## Project structure

```
Controllers/   API endpoints
Data/          AppDbContext (EF Core) and seed data
DTOs/          Request and response models
Migrations/    EF Core migrations
Models/        Database entities
Services/      Business logic / data access
```

## Endpoints

Base route: `/api/VideoGameCharacters`

| Method | Route               | Description              |
|--------|---------------------|--------------------------|
| GET    | `/`                 | List all characters      |
| GET    | `/{characterId}`    | Get a character by id    |
| POST   | `/`                 | Create a new character   |
| PUT    | `/{characterId}`    | Update a character       |
| DELETE | `/{characterId}`    | Delete a character       |

Example body for `POST` / `PUT`:

```json
{
  "name": "Samus",
  "game": "Metroid",
  "role": "Hero"
}
```

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express or LocalDB works)
- EF Core CLI: `dotnet tool install --global dotnet-ef`

### 1. Configure the connection string

Edit `appsettings.json` and point `DefaultConnection` to your SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER\\SQLEXPRESS;Database=VideoGameCharacterDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 2. Create the database

```bash
dotnet ef database update
```

This creates the `VideoGameCharacterDb` database and seeds it with a few characters (Mario, Link, Bowser and Zelda).

### 3. Run the API

```bash
dotnet run
```

In the Development environment, the interactive API reference is available at:

- Scalar UI: `http://localhost:5255/scalar/v1`
- OpenAPI document: `http://localhost:5255/openapi/v1.json`

## Credits

Built by following the YouTube tutorial: <https://www.youtube.com/watch?v=RwQVRXEs370>.
