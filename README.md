# Web API Session-Enabled Routes

This project contains an `HTTP Module` and extensions to the `HttpRouteCollection` to enable 
session in Web API 2.

## Usage

1. Build the solution and add `WebApiSessionEnabledRoutes.dll` as a reference to your Web API 2
projects.
2. Use `config.Routes.AddHttpSessionRoute()` in your Web API initialization to register
session-enabled routes. Set `readOnlySession` to `false` for routes that only need read
access to session; set it to `true` for routes that need read and write access to session.
3. No registration of the HTTP Module is necessary--IIS will register the module automatically
on startup.
