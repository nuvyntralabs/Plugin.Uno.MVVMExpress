# Plugin.Uno.MVVMExpress Architecture

Independent Uno Platform MVVM family. **0.1.0-preview.** Aligned with the Plugin.Maui.MVVMExpress 1.3 / Plugin.Wpf.MVVMExpress 1.0 Core contract, but **not** a package reference to those families.

## Principles

1. Core is UI-framework-free (`net10.0`).
2. Host / Navigation / Dialogs target `net10.0;net10.0-desktop`.
3. ViewModels depend on `INavigator`, `IDialogs`, `IMainThread`.
4. One navigator per `Window` (`IWindowContext` / `WindowNavigatorRegistry`).
5. No sibling MauiEssentials `PackageReference`.
6. No Shell. Frame + `SectionHostViewModel` cover stack and in-place tabs.

## Packages

- `Plugin.Uno.MVVMExpress.Core` — ViewModels, commands, state, navigation abstractions
- `Plugin.Uno.MVVMExpress` — `UseUnoMvvmExpress`, `UnoDispatcherMainThread`, lifecycle
- `Plugin.Uno.MVVMExpress.Navigation` — `UnoFrameNavigator`
- `Plugin.Uno.MVVMExpress.Dialogs` — `UnoDialogs`, overlay toasts
- `Plugin.Uno.MVVMExpress.Validation` / `.Pagination` / `.Testing`
- `Plugin.Uno.MVVMExpress.Templates` — `dotnet new uno-mvvmexpress`

## Host

```csharp
builder.Services.UseUnoMvvmExpress(o => o
    .UseFrameNavigation((nav, _) => nav.Map<HomeViewModel, HomePage>("home"))
    .UseDialogs()
    .UseAuth<LoginViewModel>());
```

Put a `Frame` named `NavigationHost` in the window. Toasts must not replace `Window.Content`.
