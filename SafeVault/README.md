# SafeVault

SafeVault is a small demonstration project that illustrates secure coding practices to prevent common web vulnerabilities such as SQL Injection and Cross-Site Scripting (XSS). The repository also includes basic authentication examples, password hashing, and a simple role-based access control (RBAC) middleware.

Quick start

1. Install dependencies:

```powershell
cd d:\JsProject\coursea\SafeVault
npm install
```

2. Start (development):

```powershell
npm run dev
```

3. Run tests:

```powershell
npm test
```

Project layout

- `src/`: application source code (routes, middleware, utils, and DB layer).
- `src/routes`: Express route handlers (e.g. `users.js`).
- `src/utils`: helper utilities such as input sanitization (`validation.js`).
- `src/middleware`: middleware including role checks (`roleMiddleware.js`).
- `tests/`: automated tests (includes SQLi and XSS test cases).

Security summary

- Vulnerabilities identified:
  - SQL Injection: earlier patterns that used string concatenation for SQL queries allowed injection risks when user input was embedded directly into SQL.
  - Cross-Site Scripting (XSS): user-supplied input that could be reflected in responses without proper sanitization.
  - Insufficient input validation: some endpoints required stricter validation/normalization of user-supplied data.
  - Authentication/authorization shortcuts: this is a demo app and simplifies auth flows; production systems need token/session hardening and rate limiting.

- Fixes applied in this repository:
  - Parameterized queries / prepared statements: `src/db.js` uses `mysql2` with parameter binding (`pool.execute(sql, params)`) to prevent SQL injection.
  - Input sanitization: `src/utils/validation.js` uses the `xss` library and character allow-lists to remove or escape dangerous input.
  - Input validation: `express-validator` is applied in route handlers (e.g. `src/routes/users.js`) to enforce field shapes and lengths.
  - Secure password handling: `src/auth.js` hashes passwords using `bcrypt` with an appropriate number of salt rounds.
  - Role-based checks: `src/middleware/roleMiddleware.js` demonstrates enforcing roles on protected routes.
  - Test coverage: tests under `tests/` include SQLi and XSS scenarios to prevent regressions.

- How Copilot assisted during debugging and remediation:
  - Copilot was used as a development assistant to review code snippets and suggest secure alternatives, such as replacing string-concatenated SQL with parameterized queries and recommending the use of `xss` for sanitization.
  - It helped draft small helper functions (sanitizers and validators) and suggested concrete test cases to simulate SQL injection and XSS attacks.
  - Copilot also provided succinct explanations for why the changes reduce risk, which accelerated the review and testing cycle.

Running the app

Set required environment variables for database connection (example):

```powershell
$env:DB_HOST = 'localhost'
$env:DB_USER = 'root'
$env:DB_PASSWORD = 'secret'
$env:DB_NAME = 'safevault'
```

Then run:

```powershell
npm run dev
```

Running tests

```powershell
npm test
```

Contributing

This repository is intended for learning and demonstration. If you find issues or want to improve the security posture further (for example: add rate limiting, CSRF protections, secure session management), please open an issue or submit a pull request.

License

This demo is provided for educational purposes. Check repository headers or ask the maintainers for licensing details.
