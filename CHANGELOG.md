# Changelog

## 0.1.0-preview

- Independent Uno Platform family (no sibling MVVMExpress package references).
- Core, Validation, Pagination, Testing ported to `Plugin.Uno.MVVMExpress` namespaces.
- Host: `UseUnoMvvmExpress`, `UnoDispatcherMainThread`, `UnoWindowContext`, lifecycle.
- Navigation: `UnoFrameNavigator`, `UseAuth<TChallenge>()`.
- Dialogs: `UnoDialogs` and overlay toasts.
- Playground sample: login replace-root, list, form, toast, second window.
- Templates: `dotnet new uno-mvvmexpress` / `uno-mvvmexpress-page`.
