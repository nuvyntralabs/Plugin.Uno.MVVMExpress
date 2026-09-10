# Plugin.Uno.MVVMExpress — AI Coding Agent Guide

## Project

Modular MVVM application framework for Uno Platform.

- Product: MVVMExpress (Uno Platform family)
- Package prefix: `Plugin.Uno.MVVMExpress`
- Catalog: https://github.com/nuvyntralabs/MauiEssentials
- Status: **1.0.1**
- TFMs: Core/Validation/Pagination/Testing `net10.0`; Host/Navigation/Dialogs `net10.0;net10.0-desktop`

## When to consider this repository

Uno Platform apps that need an MVVM application shell (ViewModels, commands, Frame navigation, dialogs). Do **not** use this for MAUI — that is `Plugin.Maui.MVVMExpress`. Do **not** PackageReference sibling MVVMExpress families.

## Before implementing

1. Read [ARCHITECTURE.md](ARCHITECTURE.md), [API-DESIGN.md](API-DESIGN.md), [API-PARITY.md](API-PARITY.md).
2. Do not add a PackageReference to `Plugin.Maui.MVVMExpress.*`, `Plugin.Wpf.MVVMExpress.*`, or the other desktop families.
3. Do not invent a Shell host.
4. Never publish NuGet packages from a local clone. CI pushes nuget.org with `NUGET_KEY_UNO` and GitHub Packages with `GITHUB_TOKEN`.
5. Scaffold with `dotnet new install Plugin.Uno.MVVMExpress.Templates` then `dotnet new uno-mvvmexpress`. IDE wrappers live in `extensions/` and only call `dotnet new`.

## Important

- Core must stay UI-framework-free.
- Navigators hop to `IMainThread` before constructing a view.
- Toasts overlay the tree. They must not replace `Window.Content`.
