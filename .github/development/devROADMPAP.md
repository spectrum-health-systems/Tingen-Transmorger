# Tingen Transmorger: Development Roadmap (Development)

- `ADDED` Button to the MessageHistoryWindow that copies the opt-in message to the clipboard.
-`FIXED` Data tables now sort the dates correctly


- `MODIFIED` If a database is out of date, the background is now red
- `MODIFIED` If a database is out of date, a message is displayed in the title bar

- Leading "0"s breaks search by ID
- Minimize database
- Refactor ns:Database

## Test

- [ ] `private async Task StartApp()`
```csharp
var config = Configuration.Load(); <--[Verify]-->
...
Framework.Verify(config); <--[If the config file does not have an Import path, the app crashes.]-->
...
if (!flowControl)
{
    return; <--[The app should exit before it even gets to the main UI.]-->
}
```