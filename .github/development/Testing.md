<div align="center">

  <h1>Repository: Testing

</div>

#### CONTENTS

* [Error Codes](#notes)
* [Testing Procedures](#testing-procedures)

***

# Error Codes

* [ERR-MW8000]
* [ERR-MW8001]

***

# Testing Procedures

* [ ] `private async Task StartApp()`
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

***

<br>

<sub>Last updated: 260415 </sub>
