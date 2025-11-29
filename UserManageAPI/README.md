# UserManageAPI

A simple .NET Web API example using in-memory mock data, including CRUD operations, validation, and middleware (logging and simplified API Key authentication).

Requirements
- .NET 7 SDK installed

Run in Windows PowerShell:
```powershell
cd UserManageAPI
dotnet restore
dotnet run

```
Default API Key (for demonstration): `secret-key`. Requests must include the header `X-Api-Key: secret-key`.

Example Request (PowerShell using Invoke-RestMethod):

``powershell

# List
Invoke-RestMethod -Headers @{"X-Api-Key"="secret-key"} -Method GET -Uri "https://localhost:7001/api/users" -SkipCertificateCheck

# Create
Invoke-RestMethod -Headers @{"X-Api-Key"="secret-key"} -Method POST -Uri "https://localhost:7001/api/users" -Body (@{Name='Charlie';Email='charlie@example.com';Age=29} | ConvertTo-Json) -ContentType 'application/json' -SkipCertificateCheck

```

Rating Checklist (25 points)

- (5) GitHub Repository: Please push this directory to GitHub (description in README).

- (5) CRUD: Includes GET/POST/PUT/DELETE statements in `Controllers/UsersController.cs`.

- (5) Copilot Debugging: Copilot is recommended for debugging and fixing in VS Code.

- (5) Authentication: Request DTOs are authenticated using `DataAnnotations` (in the `DTOs` folder).

- (5) Middleware: Includes `RequestLoggingMiddleware` and `ApiKeyAuthMiddleware`.
