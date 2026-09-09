# Plugin.Uno.MVVMExpress

Modular MVVM for **Uno Platform** on .NET 10: ViewModels, async commands, Frame navigation, dialogs, validation, pagination.

**Product:** MVVMExpress (Uno Platform family)
**Package prefix:** `Plugin.Uno.MVVMExpress`
**Status:** `1.0.0`
**This is not** Plugin.Maui.MVVMExpress, Plugin.Wpf.MVVMExpress, or the other desktop families. Independent port — no PackageReference to those packages.

[![NuGet](https://img.shields.io/nuget/v/Plugin.Uno.MVVMExpress.Core.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.Uno.MVVMExpress.Core)

Author: [Niladri Prasad Padhy](https://github.com/NiladriPadhy) · Catalog: [MauiEssentials](https://github.com/nuvyntralabs/MauiEssentials) · License: MIT

## Install

```bash
dotnet add package Plugin.Uno.MVVMExpress.Core
dotnet add package Plugin.Uno.MVVMExpress
dotnet add package Plugin.Uno.MVVMExpress.Navigation
dotnet add package Plugin.Uno.MVVMExpress.Dialogs
```

```csharp
builder.Services.UseUnoMvvmExpress(o => o
    .UseFrameNavigation((nav, _) => nav
        .Map<HomeViewModel, HomePage>("home"))
    .UseDialogs()
    .UseAuth<LoginViewModel>());
```

There is no Shell host. Use a `Frame` named `NavigationHost`.

## Templates and IDE extensions

| Host | How |
| --- | --- |
| CLI | `Plugin.Uno.MVVMExpress.Templates` |
| Visual Studio Code | Search Uno Platform MVVMExpress |
| Visual Studio 2022+ | Search Uno Platform MVVMExpress |

Extensions install the NuGet template pack and run `dotnet new`. Marketplace publish is manual from the `ide-extensions` workflow artifact.

## Templates

```bash
dotnet new install Plugin.Uno.MVVMExpress.Templates
dotnet new uno-mvvmexpress -n MyApp
dotnet new uno-mvvmexpress-page -n Catalog --namespace MyApp
```

## Packages

| Package | TFM | Role |
| --- | --- | --- |
| `Plugin.Uno.MVVMExpress.Core` | `net10.0` | ViewModels, commands, state, abstractions |
| `Plugin.Uno.MVVMExpress` | `net10.0;net10.0-desktop` | Host, dispatcher, lifecycle |
| `Plugin.Uno.MVVMExpress.Navigation` | `net10.0;net10.0-desktop` | `UnoFrameNavigator` |
| `Plugin.Uno.MVVMExpress.Dialogs` | `net10.0;net10.0-desktop` | `UnoDialogs` + overlay toast |
| `Plugin.Uno.MVVMExpress.Validation` | `net10.0` | DataAnnotations |
| `Plugin.Uno.MVVMExpress.Pagination` | `net10.0` | Lists / search |
| `Plugin.Uno.MVVMExpress.Testing` | `net10.0` | Fakes / leak probe |
| `Plugin.Uno.MVVMExpress.Templates` | `net10.0` | `dotnet new uno-mvvmexpress` |

Playground: `samples/Playground`. Docs: [getting started](docs/getting-started.md) · [API design](API-DESIGN.md) · [parity](API-PARITY.md).

Usual alternative: [CommunityToolkit.Mvvm](https://www.nuget.org/packages/CommunityToolkit.Mvvm).
