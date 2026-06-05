# AGENTS.md

## Build & Run

- Build: `dotnet build Portafolio.sln`
- Run: `dotnet run --project Portafolio`
- No test project exists; do not attempt to run tests.

## Email Configuration (Contact Form)

Emails are sent via **Resend** (HTTP API, not SMTP — SMTP is blocked by Render).

### Local development (user-secrets)
```
dotnet user-secrets set "CONFIGURACIONES_EMAIL:RESEND_APITOKEN" "re_xxx" --project Portafolio
```

### Production (Render env vars)
- `CONFIGURACIONES_EMAIL__RESEND_APITOKEN` — your Resend API key (`re_xxx`)

`FROM` (`onboarding@resend.dev`) and `TO` are already in `appsettings.json`.

## Deploy (Render)

- Runtime: **Docker** (Dockerfile at repo root)
- Required env vars on Render: `CONFIGURACIONES_EMAIL__EMAIL`, `CONFIGURACIONES_EMAIL__PASSWORD`
- `Program.cs` reads `PORT` env var and uses `ForwardedHeaders` for Render's proxy

## Conventions

- All code is in **Spanish**: namespaces, class names, methods, variables (e.g. `Servicios`, `ObtenerProyecto`, `ContactoViewModel`). Maintain this convention.
- Project data is **hardcoded** in `Servicios/RepositoryProjects.cs` — no database or ORM.
- Single controller (`HomeController`) handles all routes.
