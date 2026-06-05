# AGENTS.md

## Build & Run

- Build: `dotnet build Portafolio.sln`
- Run: `dotnet run --project Portafolio`
- No test project exists; do not attempt to run tests.

## Email Configuration (Contact Form)

The contact form (`ServicioEmailGmail`) requires SMTP credentials via **user-secrets**:

```
dotnet user-secrets set "CONFIGURACIONES_EMAIL:EMAIL" "<email>" --project Portafolio
dotnet user-secrets set "CONFIGURACIONES_EMAIL:PASSWORD" "<app-password>" --project Portafolio
```

HOST (`smtp.gmail.com`) and PUERTO (`587`) are already in `appsettings.json`.

## Deploy (Render)

- Runtime: **Docker** (Dockerfile at repo root)
- Required env vars on Render: `CONFIGURACIONES_EMAIL__EMAIL`, `CONFIGURACIONES_EMAIL__PASSWORD`
- `Program.cs` reads `PORT` env var and uses `ForwardedHeaders` for Render's proxy

## Conventions

- All code is in **Spanish**: namespaces, class names, methods, variables (e.g. `Servicios`, `ObtenerProyecto`, `ContactoViewModel`). Maintain this convention.
- Project data is **hardcoded** in `Servicios/RepositoryProjects.cs` — no database or ORM.
- Single controller (`HomeController`) handles all routes.
