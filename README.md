# Auth-App-DotNet

## 🚀 **Overview**
**Auth-App-DotNet** is a .NET 8 project designed with Clean Architecture principles. It leverages **CQRS**, **MediatR**, **FluentValidation**, and **Entity Framework Core** for modern, scalable API development. This project uses traditional API controllers, PostgreSQL as the database, and **AutoRegisterDI** for automated service registration.

#### Git Clone Repository 
       git clone https://github.com/iamhasibulhasan/auth-app-dotnet.git     

#### Docker Build & Run
       docker build -t authapp-dotnet:latest . 
       docker run -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development --name authapp-container authapp-dotnet:latest

## 📦 **Features**
- **Clean Architecture**: Ensures separation of concerns and maintainability.
- **CQRS Pattern**: Command and Query Responsibility Segregation for clear application logic.
- **MediatR**: Simplifies request/response handling and decouples business logic.
- **FluentValidation**: Streamlines request validation with a fluent API.
- **PostgreSQL**: Robust relational database for efficient data management.
- **Entity Framework Core**: Object-relational mapping for seamless database operations.
- **AutoRegisterDI**: Automatically registers services for dependency injection.

## 📂 **Project Structure**

```plaintext
📦 src
├── 📁 Core
│   ├── 📁 AuthApp.Application         # Business Logic (CQRS Handlers, MediatR)
│   ├── 📁 AuthApp.Domain              # Core Entities & Interfaces
│   └── 📁 AuthApp.Infrastructure      # Data Access (EF Core, PostgreSQL)
└── 📁 Web.Api
    └── 📁 AuthApp.Api                 # Traditional API Controllers
