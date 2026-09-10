# Plugin.Uno.MVVMExpress

Uno Platform host for MVVMExpress. Targets: `net10.0` and `net10.0-desktop`. DI, dispatcher, window context, and Loaded/Unloaded lifecycle.

Depends on [Plugin.Uno.MVVMExpress.Core](https://www.nuget.org/packages/Plugin.Uno.MVVMExpress.Core).

```csharp
var builder = Host.CreateApplicationBuilder();
builder.Services.UseUnoMvvmExpress(o => o
    .UseFrameNavigation((nav, _) => nav
        .Map<HomeViewModel, HomePage>("home"))
    .UseDialogs()
    .UseAuth<LoginViewModel>());
```

`UseUnoMvvmExpress` calls `AddMvvmExpress()`, replaces `IMainThread` with `UnoDispatcherMainThread`, and maps `IWindowContext` to `UnoWindowContext`. `UseFrameNavigation` / `UseDialogs` live in the Navigation and Dialogs packages.

## Install

```bash
dotnet add package Plugin.Uno.MVVMExpress.Core
dotnet add package Plugin.Uno.MVVMExpress
```

Version `1.0.1`. Shared / test code can stay on Core + `AddMvvmExpress()` without this package. Do not use the WinUI nupkg on Uno.

License: MIT. Niladri Padhy / MauiEssentials.
