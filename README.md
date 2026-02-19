# Student Microservice

A minimal, microservices-based .NET 10 Web API for student CRUD operations with MySQL, ready for Azure App Service deployment.

## Project Structure

```
StudentMicroservice/
├── Controllers/
│   └── StudentsController.cs    ← REST API (5 endpoints)
├── Data/
│   └── StudentDbContext.cs      ← EF Core context
├── Models/
│   └── Student.cs               ← Student entity
├── Program.cs                   ← App entry (DI, CORS, OpenAPI)
├── StudentMicroservice.csproj   ← Dependencies
└── appsettings.json             ← Configuration & DB connection string
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- MySQL Server (local or remote)

## Setup

1. **Update the MySQL connection string** in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Port=3306;Database=StudentDb;User=root;Password=your_password;"
   }
   ```

2. **Apply EF Core migrations** to create the database schema:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

   > If you don't have the EF CLI tool: `dotnet tool install --global dotnet-ef`

3. **Run the app**:

   ```bash
   dotnet run
   ```

   API available at `http://localhost:5050`

## API Endpoints

| Method   | Route                | Description        |
|----------|----------------------|--------------------|
| `GET`    | `/api/students`      | List all students  |
| `GET`    | `/api/students/{id}` | Get one student    |
| `POST`   | `/api/students`      | Create a student   |
| `PUT`    | `/api/students/{id}` | Update a student   |
| `DELETE` | `/api/students/{id}` | Delete a student   |

### Example Request

```bash
curl -X POST http://localhost:5050/api/students \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "John",
    "lastName": "Doe",
    "email": "john@example.com",
    "dateOfBirth": "2000-05-15",
    "course": "Computer Science"
  }'
```

## Azure Deployment

```bash
dotnet publish -c Release -o ./publish
```

Deploy the `./publish` folder to Azure App Service via:
- **Azure CLI**: `az webapp deploy`
- **VS Code**: Azure App Service extension
- **GitHub Actions**: CI/CD pipeline

Set the `ConnectionStrings__DefaultConnection` environment variable in Azure to point to your Azure Database for MySQL instance.
