# Todo Backend

This is the backend part of a Todo application developed using .NET Core 5 and following the Clean Architecture methodology. The project utilizes SQL Server and Entity Framework. Follow the steps below to get started with the project.

## Requirements

- .NET 5 SDK
- SQL Server (local or remote)

## Project Structure

The project follows the Clean Architecture methodology, where each of the following projects represents a different layer:

- **Entities**: Contains the database tables and data models.
- **DataAccess**: Contains the code for interacting with the database.
- **Core**: Contains common code for general use.
- **Business**: Contains the code implementing the business logic.
- **API**: Contains the code for the RESTful API.

## Installation

1. Clone the project to your local machine:

```bash
git clone https://github.com/hakannyucel/todo-backend.git
```

2. Create a new database in SQL Server.

3. Update the SQL Server connection string in the `appsettings.json` file:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=your_server;Initial Catalog=your_database;User ID=your_username;Password=your_password"
}
```

4. Navigate to the project folder in the command line:

```bash
cd todo-backend
```

5. Build the project:

```bash
dotnet build
```

6. To create the database and add sample data, run the following commands sequentially:

```bash
dotnet ef database update --project DataAccess
```

7. Start the project:

```bash
dotnet run --project API
```

8. Open your browser and go to http://localhost:5000/swagger to access the Swagger interface and start using the API.

## Technologies Used

The project follows the Clean Architecture methodology, where each of the following projects represents a different layer:

- .NET 5
- SQL Server
- Entity Framework Core
- FluentValidation
- Autofac
- log4net

## Contributing

If you would like to contribute to the project, please follow the steps below:

1. Fork the project to your own GitHub account.
2. Create a new branch: `git checkout -b my-new-feature`
3. Make your desired changes and commit them: `git commit -am 'Add some feature'`
4. Push the branch to your fork: `git push origin my-new-feature`
5. Create a new pull request (PR) and initiate a discussion about your changes.
