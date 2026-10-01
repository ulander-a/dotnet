| Day           | Focus                   | Goal                                                                                                  |
| ------------- | ----------------------- | ----------------------------------------------------------------------------------------------------- |
| **1 — Today** | **C# + .NET basics**    | C# syntax, LINQ, generics, interfaces, `async/await`, `Task`, nullable types, `.csproj`, `dotnet` CLI |
| **2**         | **C# in practice**      | Build a small console app; get comfortable reading idiomatic C#                                       |
| **3**         | **ASP.NET Core**        | Build a REST API; understand `Program.cs`, controllers, routing                                       |
| **4**         | **ASP.NET Core**        | DI, middleware, configuration, logging, authentication basics                                         |
| **5**         | **EF Core + SQL**       | `DbContext`, LINQ, relationships, migrations, SQL Server                                              |
| **6**         | **Azure fundamentals**  | App Service, Azure SQL, Blob Storage, Service Bus, Key Vault, Application Insights                    |
| **7**         | **Entra ID**            | OAuth/OIDC, tokens, app registrations, managed identity, permissions                                  |
| **8**         | **Microsoft Graph**     | Connect .NET → Graph → Outlook/SharePoint/Teams                                                       |
| **9**         | **Integration day**     | Build a small enterprise-style API using Azure + Graph                                                |
| **10**        | **Real-world codebase** | Read a modern .NET project; understand architecture and conventions                                   |

## Resources

Official docs per day. Background: JS/Node + PHP — the C# tour's JS/TS tips page is the fastest way in.

### Day 1 — C# + .NET basics
- [_] [A tour of C#: tips for JavaScript/TypeScript developers](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tips-for-javascript-developers)
- [_] [Language Integrated Query (LINQ)](https://learn.microsoft.com/en-us/dotnet/csharp/linq/)
- [_] [Generic type parameters](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-type-parameters) · [Generics in .NET](https://learn.microsoft.com/en-us/dotnet/standard/generics/)
- [_] [Interfaces — define behavior for multiple types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces)
- [_] [Asynchronous programming in C#](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/) · [Task asynchronous programming model](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model)
- [_] [Tutorial: Nullable and non-nullable reference types](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/nullable-reference-types)
- [_] [.NET project SDK overview (.csproj)](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview)
- [_] [.NET CLI overview](https://learn.microsoft.com/en-us/dotnet/core/tools/)

### Day 2 — C# in practice
- [A tour of C# — overview](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/overview)

### Day 3–4 — ASP.NET Core
- [ASP.NET Core fundamentals overview](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/)
- [Tutorial: Create a controller-based web API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api) · [Create web APIs with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [Routing in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing)
- [Dependency injection in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
- [ASP.NET Core middleware](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/)
- [Configuration in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [Logging in .NET and ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/)
- [Overview of ASP.NET Core authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/)

### Day 5 — EF Core + SQL
- [EF Core overview](https://learn.microsoft.com/en-us/ef/core/)
- [Tutorial: Get started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app)
- [DbContext lifetime, configuration, and initialization](https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/)
- [Introduction to relationships](https://learn.microsoft.com/en-us/ef/core/modeling/relationships)
- [Migrations overview](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [SQL Server database provider](https://learn.microsoft.com/en-us/ef/core/providers/sql-server/)

### Day 6 — Azure fundamentals
- [Azure App Service overview](https://learn.microsoft.com/en-us/azure/app-service/overview)
- [What is Azure SQL Database?](https://learn.microsoft.com/en-us/azure/azure-sql/database/sql-database-paas-overview?view=azuresql)
- [Azure Blob Storage documentation](https://learn.microsoft.com/en-us/azure/storage/blobs/)
- [Introduction to Azure Service Bus](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview)
- [Azure Key Vault overview](https://learn.microsoft.com/en-us/azure/key-vault/general/overview)
- [Application Insights overview](https://learn.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)

### Day 7 — Entra ID
- [OAuth 2.0 and OpenID Connect protocols on the Microsoft identity platform](https://learn.microsoft.com/en-us/entra/identity-platform/v2-protocols)
- [Quickstart: Register an app with Microsoft Entra ID](https://learn.microsoft.com/en-us/entra/identity-platform/quickstart-register-app)
- [Managed identities for Azure resources — overview](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/overview)

### Day 8 — Microsoft Graph
- [Microsoft Graph overview](https://learn.microsoft.com/en-us/graph/overview)
- [Build .NET apps with Microsoft Graph (tutorial)](https://learn.microsoft.com/en-us/graph/tutorials/dotnet)
- [Install a Microsoft Graph SDK](https://learn.microsoft.com/en-us/graph/sdks/sdk-installation)

### Day 9 — Integration day
- [Key Azure services for developers](https://learn.microsoft.com/en-us/azure/developer/intro/azure-developer-key-services) (good checklist while wiring Azure + Graph together)

### Day 10 — Real-world codebase
- [dotnet/eShop](https://github.com/dotnet/eShop) — official .NET reference e-commerce app (.NET Aspire, services-based architecture)
