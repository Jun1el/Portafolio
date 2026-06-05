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

HOST (`smtp.gmail.com`) and PUERTO (`587`) are already in `appsettings.Development.json`.

## Conventions

- All code is in **Spanish**: namespaces, class names, methods, variables (e.g. `Servicios`, `ObtenerProyecto`, `ContactoViewModel`). Maintain this convention.
- Project data is **hardcoded** in `Servicios/RepositoryProjects.cs` — no database or ORM.
- Single controller (`HomeController`) handles all routes.
