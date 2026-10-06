| Day           | Focus                         | Goal                                                                                                                                      |
| ------------- | ----------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| **1** | **C# + .NET basics**          | `dotnet` CLI, `.csproj`, NuGet; create and run a console app; C# vs JS/TS, LINQ, generics, interfaces, `async/await`/`Task`, records, pattern matching, nullable reference types |
| **2**         | **C# in practice**            | Build a console app that calls an HTTP API (`HttpClient`, `System.Text.Json`), wire it with DI + Generic Host, add xUnit tests           |
| **3**         | **ASP.NET Core: APIs**        | Build the same CRUD API twice, minimal API and controllers; understand `Program.cs`, routing, OpenAPI                                     |
| **4**         | **ASP.NET Core: the host**    | DI lifetimes, middleware pipeline, configuration + options, User Secrets, environments, logging, error handling, integration tests       |
| **5**         | **EF Core + SQL**             | `DbContext`, LINQ queries, relationships, migrations; move the Day 3–4 API onto SQL Server (local in Docker)                              |
| **6**         | **Azure fundamentals**        | `az`/`azd` CLI, `DefaultAzureCredential`; deploy an ASP.NET Core + Azure SQL app to App Service; Key Vault, Application Insights         |
| **7**         | **Entra ID**                  | OAuth/OIDC, access tokens, app registrations, delegated vs application permissions; protect an API with JWT bearer + Microsoft.Identity.Web |
| **8**         | **Microsoft Graph**           | Graph SDK; call Outlook/SharePoint/Teams with delegated and app-only auth; pick least-privilege permissions                              |
| **9**         | **Integration day**           | Protected API → Graph via on-behalf-of → Azure SQL; deploy to App Service with managed identity                                          |
| **10**        | **Real-world codebase**       | Containers + Aspire; run and read dotnet/eShop; understand its architecture and conventions                                              |

## Resources

Official docs per day, in the intended order. Background: JS/Node + PHP + Linux — the C# tour's JS/TS tips page is the fastest way in. `[x]` = done, `[ ]` = todo.

### Day 1 — C# + .NET basics
*Deliverable: a console project you created with `dotnet new`, with a NuGet package added and nullable warnings fixed.*
- [x] [.NET CLI overview](https://learn.microsoft.com/en-us/dotnet/core/tools/)
- [x] [.NET project SDK overview (.csproj)](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview)
- [x] [Install and manage NuGet packages with the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) (NuGet ≈ npm/Composer)
- [x] [Tutorial: Create a .NET console application (VS Code)](https://learn.microsoft.com/en-us/dotnet/core/tutorials/create-console-app?pivots=vscode)
- [x] [A tour of C#: tips for JavaScript/TypeScript developers](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tips-for-javascript-developers)
- [x] [Language Integrated Query (LINQ)](https://learn.microsoft.com/en-us/dotnet/csharp/linq/)
- [x] [Generic type parameters](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-type-parameters) · [Generics in .NET](https://learn.microsoft.com/en-us/dotnet/standard/generics/)
- [x] [Interfaces — define behavior for multiple types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces)
- [x] [Asynchronous programming in C#](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/) · [Task asynchronous programming model](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model)
- [x] [Record types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records) · [Pattern matching](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/patterns/pattern-matching)
- [x] [Tutorial: Nullable and non-nullable reference types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/nullable-reference-types)

### Day 2 — C# in practice
*Deliverable: a console app that fetches and deserializes JSON from a real API, uses DI + configuration via the Generic Host, and has a passing `dotnet test` project.*
- [x] [Tutorial: Make HTTP requests in a .NET console app](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient)
- [x] [.NET Generic Host](https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host)
- [ ] [Tutorial: Use dependency injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection/usage) (DI is built in and everywhere in .NET; learn it here, before ASP.NET)
- [ ] [Unit testing C# with xUnit and `dotnet test`](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit)

### Day 3 — ASP.NET Core: APIs
*Deliverable: a TodoApi built as a minimal API and as controllers, explored through the OpenAPI document.*
- [ ] [ASP.NET Core fundamentals overview](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/)
- [ ] [APIs overview: minimal APIs vs controllers](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/apis)
- [ ] [Tutorial: Create a minimal API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api) · [Minimal APIs quick reference](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)
- [ ] [Tutorial: Create a controller-based web API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api) · [Create web APIs with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [ ] [Routing in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing)
- [ ] [OpenAPI support in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/overview)

### Day 4 — ASP.NET Core: the host
*Deliverable: the minimal API with a typed options class, a secret in User Secrets, custom middleware, ProblemDetails errors, and one `WebApplicationFactory` integration test.*
- [ ] [Dependency injection in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection) (focus: singleton vs scoped vs transient)
- [ ] [ASP.NET Core middleware](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/)
- [ ] [Configuration in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/) · [Options pattern](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options)
- [ ] [Safe storage of app secrets in development (User Secrets)](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) (replaces `.env`)
- [ ] [Runtime environments](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments)
- [ ] [Logging in .NET and ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/)
- [ ] [Handle errors in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling)
- [ ] [Integration tests in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests)

### Day 5 — EF Core + SQL
*Deliverable: the Day 3–4 API on SQL Server, with two related entities and migrations applied via `dotnet ef`.*
- [ ] [EF Core overview](https://learn.microsoft.com/en-us/ef/core/)
- [ ] [Tutorial: Get started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app)
- [ ] [Run SQL Server in a Docker container](https://learn.microsoft.com/en-us/sql/linux/install-upgrade/quickstart-install-docker)
- [ ] [EF Core tools reference (`dotnet ef`)](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- [ ] [DbContext lifetime, configuration, and initialization](https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/)
- [ ] [Introduction to relationships](https://learn.microsoft.com/en-us/ef/core/modeling/relationships)
- [ ] [Migrations overview](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [ ] [SQL Server database provider](https://learn.microsoft.com/en-us/ef/core/providers/sql-server/)

### Day 6 — Azure fundamentals
*Deliverable: an ASP.NET Core + Azure SQL app running on App Service, deployed with `azd`, then torn down with `azd down`.*
- [ ] [Install the Azure CLI on Windows](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows) · [Install the Azure Developer CLI](https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/install-azd)
- [ ] [What is the Azure Developer CLI (`azd`)?](https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/overview)
- [ ] [Authenticate .NET apps to Azure services](https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication/) · [Local dev with developer accounts (`DefaultAzureCredential`)](https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication/local-development-dev-accounts)
- [ ] [Azure App Service overview](https://learn.microsoft.com/en-us/azure/app-service/overview)
- [ ] [What is Azure SQL Database?](https://learn.microsoft.com/en-us/azure/azure-sql/database/sql-database-paas-overview?view=azuresql)
- [ ] [Tutorial: Deploy an ASP.NET Core + Azure SQL app to App Service](https://learn.microsoft.com/en-us/azure/app-service/tutorial-dotnetcore-sqldb-app)
- [ ] [Azure Key Vault overview](https://learn.microsoft.com/en-us/azure/key-vault/general/overview) · [Key Vault configuration provider](https://learn.microsoft.com/en-us/aspnet/core/security/key-vault-configuration)
- [ ] [Application Insights overview](https://learn.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview) · [Enable OpenTelemetry in Application Insights](https://learn.microsoft.com/en-us/azure/azure-monitor/app/opentelemetry-enable)
- [ ] Optional skim: [Azure Blob Storage](https://learn.microsoft.com/en-us/azure/storage/blobs/) · [Azure Service Bus](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview)

### Day 7 — Entra ID
*Deliverable: a protected web API that returns 401 without a token and accepts both a user token (scope) and an app token (app role), tested with cURL.*
- [ ] [OAuth 2.0 and OpenID Connect protocols on the Microsoft identity platform](https://learn.microsoft.com/en-us/entra/identity-platform/v2-protocols)
- [ ] [Access tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)
- [ ] [Permissions and consent: delegated vs application](https://learn.microsoft.com/en-us/entra/identity-platform/permissions-consent-overview)
- [ ] [Quickstart: Register an app with Microsoft Entra ID](https://learn.microsoft.com/en-us/entra/identity-platform/quickstart-register-app)
- [ ] [Overview of ASP.NET Core authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/) · [Configure JWT bearer authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-jwt-bearer-authentication)
- [ ] [Microsoft Identity Web documentation](https://learn.microsoft.com/en-us/entra/msidweb/)
- [ ] [Quickstart: Register and expose a protected web API (scopes + app roles)](https://learn.microsoft.com/en-us/entra/identity-platform/quickstart-web-api-dotnet-protect-app)
- [ ] [Tutorial: Build and secure an ASP.NET Core web API](https://learn.microsoft.com/en-us/entra/identity-platform/tutorial-web-api-dotnet-core-build-app) · [Call it with cURL](https://learn.microsoft.com/en-us/entra/identity-platform/howto-call-a-web-api-with-curl)
- [ ] [Configure protected web API apps](https://learn.microsoft.com/en-us/entra/identity-platform/scenario-protected-web-api-app-configuration)
- [ ] [Managed identities for Azure resources — overview](https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/overview)

### Day 8 — Microsoft Graph
*Deliverable: a console app that reads your mail/profile (delegated) and lists users or sites (app-only), with permissions you can justify.*
- [ ] [Microsoft Graph overview](https://learn.microsoft.com/en-us/graph/overview)
- [ ] [Graph Explorer](https://developer.microsoft.com/en-us/graph/graph-explorer) (try queries before writing code)
- [ ] [Microsoft Graph SDK overview](https://learn.microsoft.com/en-us/graph/sdks/sdks-overview) · [Install a Microsoft Graph SDK](https://learn.microsoft.com/en-us/graph/sdks/sdk-installation)
- [ ] [Build .NET apps with Microsoft Graph (delegated tutorial)](https://learn.microsoft.com/en-us/graph/tutorials/dotnet)
- [ ] [Build .NET apps with Microsoft Graph and app-only auth](https://learn.microsoft.com/en-us/graph/tutorials/dotnet-app-only)
- [ ] [Microsoft Graph permissions reference](https://learn.microsoft.com/en-us/graph/permissions-reference)
- [ ] Skim per workload: [Outlook mail](https://learn.microsoft.com/en-us/graph/outlook-mail-concept-overview) · [SharePoint sites](https://learn.microsoft.com/en-us/graph/api/resources/sharepoint) · [Teams](https://learn.microsoft.com/en-us/graph/teams-concept-overview)

### Day 9 — Integration day
*Deliverable: the Day 7 protected API calls Graph on behalf of the signed-in user, stores data in Azure SQL, and runs on App Service using managed identity (no secrets in config).*
- [ ] [OAuth 2.0 on-behalf-of flow](https://learn.microsoft.com/en-us/entra/identity-platform/v2-oauth2-on-behalf-of-flow)
- [ ] [Configure a web API that calls web APIs (Microsoft.Identity.Web)](https://learn.microsoft.com/en-us/entra/identity-platform/scenario-web-api-call-api-app-configuration)
- [ ] [Key Azure services for developers](https://learn.microsoft.com/en-us/azure/developer/intro/azure-developer-key-services) (good checklist while wiring Azure + Graph together)

### Day 10 — Real-world codebase
*Deliverable: eShop running locally, plus a one-page map of its services, how they talk, and where DI, config, auth and EF live.*
- [ ] [Tutorial: Containerize a .NET app with Docker](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container)
- [ ] [What is Aspire?](https://aspire.dev/get-started/what-is-aspire/)
- [ ] [dotnet/eShop](https://github.com/dotnet/eShop) — official .NET reference e-commerce app (Aspire, services-based architecture, minimal APIs)
- [ ] Optional: [Architect modern web applications with ASP.NET Core and Azure (e-book)](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/)
