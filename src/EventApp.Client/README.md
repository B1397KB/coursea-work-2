# EventApp.Client

This is a front-end client project using Blazor WebAssembly for displaying an event list, user registration, and attendance management.

Main Functions:

- Display the event list

- Register for events

- View attendance status

Project Structure (Important Files):

- `Program.cs` - Blazor WASM startup and service registration.

- `App.razor` - Routing and page layout.

- `Pages/` - Contains pages such as `Index.razor`, `Events.razor`, `Register.razor`, and `Attendance.razor`.

- `Components/EventCard.razor` - Event card component.

- `Services/IEventService.cs`, `Services/EventService.cs` - Services for interacting with the backend.

System Requirements:

- .NET SDK 8.0

- Run in the project root directory:

``powershell
cd src\EventApp.Client
dotnet build
dotnet run

```

Use Copilot to assist this project:

- Code completion and generation: When writing pages, components, and services, Copilot can suggest properties, methods, and Razor fragments based on context.

- Fixing compilation errors: Copilot can suggest fixes based on error messages (e.g., adding missing `@using`, adjusting binding syntax, etc.).

- Writing unit and integration tests: Generate test templates to cover critical service logic.