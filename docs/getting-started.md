# Getting started

Scaffold an app:

```bash
dotnet new install Plugin.Uno.MVVMExpress.Templates
dotnet new uno-mvvmexpress -n MyApp
```

Or add the packages to an existing Uno Platform project:

```bash
dotnet add package Plugin.Uno.MVVMExpress.Core
dotnet add package Plugin.Uno.MVVMExpress
dotnet add package Plugin.Uno.MVVMExpress.Navigation
dotnet add package Plugin.Uno.MVVMExpress.Dialogs
```

```csharp
var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<IAuthState, DemoAuthState>();
builder.Services.UseUnoMvvmExpress(o => o
    .UseFrameNavigation((nav, _) => nav
        .Map<LoginViewModel, LoginPage>("login")
        .Map<HomeViewModel, HomePage>("home"))
    .UseDialogs()
    .UseAuth<LoginViewModel>());
```

Add a `Frame` named `NavigationHost` to the main window. Toasts must not replace `Window.Content`.

Demo credentials in Playground: `demo@mvvmexpress.dev` / `secret`.

After sign-in, `ResetAsync<HomeViewModel>()` replaces the journal so Back cannot return to login.
