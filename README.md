# FilmAPI
## Description
FilmAPI is Web API built using ASP.NET Core. It's designed to handle various operations related to films and characters within a film database. The API uses Entity Framework Core for database interactions. From fetching details about movies, franchises and characters to updating and deleting them, FilmAPI stands as a one-stop solution.

## Features
Fetch, Update, Post, Delete operations for films, franchises and characters.
Built with ASP.NET Core, ensuring high performance and scalability.
Utilizes Entity Framework Core for efficient database operations.

## Installation
- .NET 6.0 SDK or higher installed
- An IDE like Visual Studio or VS Code for development.
- Clone the repository
- Restore packages (dotnet restore)
- Ensure that the connection string in appsettings.json is correct. Then run:
  dotnet ef database update (EntityFrameworkCore\update-database in package manager console).
- Run application

## Tools used
- ASP.NET Core: For creating the Web API.
- Entity Framework Core: For handling database operations.
- Automapper: For mapping entity objects to DTOs.
- Swagger
- Git: For version control.

## Usage
After running the application, you can use various endpoints to perform CRUD operations on films, franchises and characters. Example for characters:
- GET /api/characters: Fetch all characters.
- GET /api/characters/{id}: Fetch a character by ID.
- POST /api/characters: Create a new character.
- PUT /api/characters/{id}: Update an existing character.
- DELETE /api/characters/{id}: Delete a character by ID.

  ## Authors
  Jacob Langevei
  Kasper Brudal
