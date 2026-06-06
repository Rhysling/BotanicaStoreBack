# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Build everything
dotnet build BotanicaStoreBack.sln

# Run the Web API
dotnet run --project BotanicaStoreBack

# Run the batch utility console app
dotnet run --project BotanicaStoreBack.Runner
```

The Runner project has a `Program.cs` that calls one utility at a time via commented/uncommented lines (ColorCardMaker, SlugMaker, PicAudit, DtConversion). Toggle which utility runs there.

There are no test projects. There is no CI/CD configuration.

## Architecture

**BotanicaStoreBack** is an ASP.NET Core 10.0 REST API backend for a plant store e-commerce system, with plant catalog, wish lists, shopping, and admin tools. It serves a SPA frontend from `wwwroot/` with fallback routing (non-API, non-extension requests → `index.html`).

### Projects

| Project | Type | Purpose |
|---|---|---|
| `BotanicaStoreBack` | Web API | Main HTTP entry point, controllers, services, auth |
| `BotanicaStoreBack.Repo` | Class library | Data access: NPoco repositories and generated entity models |
| `BotanicaStoreBack.ColorCards` | Class library | PDF/Word document generation for plant color cards |
| `BotanicaStoreBack.Runner` | Console app | Batch utilities: slug generation, picture auditing, color cards |
| `BotanicaStoreBack.Db` | SQL project | SQL Server schema management |

### Key libraries

- **NPoco 6.2.0** — micro-ORM; no Entity Framework
- **Microsoft.Data.Sqlite** — SQLite ADO.NET driver
- **JwtBearer** — JWT authentication
- **Mailgun** — email via HTTP API
- **Slugify.Core** — URL slug generation
- **sautinsoft.document** — Word/PDF generation (ColorCards project)

### Data access

All repositories extend `RepositoryBase` (in `Repo/Repositories/`), which manages the NPoco `Database` instance configured for SQLite (`DatabaseType.SQLite`, `SqliteFactory`). Entity models live in `Repo/Models/Generated/` (NPoco T4-generated from schema). There are both table models and view models (`vwListedPlant`, `vwWishListEmail`, etc.). Some entity properties store JSON (e.g., `Plant.Pics` is a JSON array of `PlantPicId` objects).

Repositories are registered as transient services and injected into controllers. The SQLite database file path is resolved at startup in `Program.cs`: in production it is `<cwd>/Db/BotanicaDevSqlite.db`; in development it is resolved relative to the `BotanicaStoreBack/Db/` folder within the repo.

### Endpoints

- **Public:** `/api/[controller]` — ListedPlants, WishList, Login, Calendar, Links, etc.
- **Admin:** `/api/admin/[controller]` — Plants, PlantPrice, Users, Pictures, etc.

Admin endpoints are protected by `AdminAuthorizeAttribute` (JWT required; IsAdmin claim must be true). Admin is determined by `@polson.com` email domain or explicit `IsAdmin` flag on the User record.

### Configuration

`appsettings.json` holds non-sensitive config (JWT Issuer, Mailgun URLs, TaxRate `0.1025`, IsProductionString flag). Sensitive values are injected via environment variables:

- `BotanicaStoreAdminPw`
- Mailgun auth key

`AppSettings.IsProduction` is `true` unless `IsProductionString` is the literal string `"false"`. Development (`appsettings.Development.json`) sets `IsProductionString: "false"`, which disables HTTPS redirect, opens CORS to all origins, and resolves the SQLite DB path from the repo rather than the deploy directory.

`AppSettings.cs` (`Models/Core/`) exposes a static `Settings` singleton populated at startup.

### TypeScript model generation

Controllers/actions marked with `TypeScriptModelAttribute` participate in automatic TypeScript interface generation for the frontend. This is a custom filter defined in `Services/`.
