# Changelog

## 1.0.1

- Pack Host / Navigation / Dialogs / Templates README files as real markdown so nuget.org renders them.

## 1.0.0

- First stable release. Full app templates, IDE extensions, host/navigator tests, and known limitations.
- VS Code Marketplace id is `nuvyntralabs.plugin-uno-mvvmexpress` with display name **Plugin.Uno.MVVMExpress** (`uno-mvvmexpress` / **Uno MVVMExpress** were reserved after a deleted listing).

## 0.1.0-preview

- Independent Uno Platform family (no sibling MVVMExpress package references).
- Core, Validation, Pagination, Testing ported to `Plugin.Uno.MVVMExpress` namespaces.
- Host: `UseUnoMvvmExpress`, `UnoDispatcherMainThread`, `UnoWindowContext`, lifecycle.
- Navigation: `UnoFrameNavigator`, `UseAuth<TChallenge>()`.
- Dialogs: `UnoDialogs` and overlay toasts.
- Playground sample: login replace-root, list, form, toast, second window.
- Templates: `dotnet new uno-mvvmexpress` / `uno-mvvmexpress-page`.
