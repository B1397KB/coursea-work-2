# InventoryHub - FullStackApp

This workspace contains a Blazor WebAssembly client (`ClientApp`) and a Minimal API server (`ServerApp`). The sample demonstrates front-end/back-end integration and basic error handling.

Project layout
- `ClientApp/` — Blazor WebAssembly front-end. Key files: `Pages/FetchProducts.razor`, `Program.cs`, `Layout/NavMenu.razor`.
- `ServerApp/` — Minimal API back-end. Key file: `Program.cs` (exposes `/api/productlist`).

Run locally (PowerShell)
1. Start the server on port 5002:

```powershell
dotnet run --urls "http://localhost:5002"
```

2. Start the client on port 5003:

```powershell
dotnet run --urls "http://localhost:5003"
```

3. Verify:
- API: `http://localhost:5002/api/productlist` returns the JSON product list with nested `Category` objects.
- UI: `http://localhost:5003/fetchproducts` shows the product list.

Development notes
- CORS: Server uses `AllowAnyOrigin` for development to avoid CORS blocking. Restrict origins in production.
- HttpClient: `FetchProducts.razor` calls the server at `http://localhost:5002/api/productlist`. Adjust the URL if you change ports or host.

# Reflection — Using Copilot for InventoryHub

What I implemented
- Created a Minimal API endpoint `/api/productlist` that returns product objects with nested `Category` data.
- Implemented a Blazor component `ClientApp/Pages/FetchProducts.razor` that calls the API, deserializes JSON, handles timeouts and malformed JSON, and displays results.
- Enabled development CORS policy on the server to allow the client to call the API during local development.

How Copilot assisted
- Scaffolding suggestions: Copilot suggested minimal API patterns and typical response shapes for product lists.
- Error handling: Copilot recommended using `HttpClient`, `EnsureSuccessStatusCode`, cancellation tokens for timeouts, and try/catch to handle malformed JSON and network errors.
- Debugging guidance: Copilot guided resolving common integration issues — incorrect route (`/api/products` → `/api/productlist`) and adding a CORS policy to avoid browser blocking.

Challenges and resolutions
- Incorrect route: The front-end was originally using `/api/products`. I updated the front-end call to `/api/productlist` to match the server.
- CORS errors: Added `builder.Services.AddCors()` and `app.UseCors(...)` in `Program.cs` to allow requests from the client during development.
- Malformed JSON: Added defensive deserialization with `JsonSerializer.Deserialize<T[]>` under a try/catch and surfaced user-friendly error messages.

Next steps / improvements
- Replace anonymous response objects with strong typed DTOs on the server (`record Product`, `record Category`) and return typed results.
- Add caching to the API or client-side caching to reduce redundant calls.
- Add tests for the API response shape and front-end deserialization.
- Tighten CORS policy for production and add logging for better observability.

Notes about Copilot usage
- Use Copilot as a coding assistant: accept suggestions, but verify and adjust them to match your project's conventions and security requirements.
- Copilot accelerates routine code patterns (HTTP calls, JSON handling, API routes) but the developer should review for production readiness.
