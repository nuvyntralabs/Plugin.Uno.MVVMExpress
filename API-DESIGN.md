# Plugin.Uno.MVVMExpress Public API Design

**0.1.0-preview** contract. Namespaces start with `Plugin.Uno.MVVMExpress`. Core shapes match Maui 1.3 / WPF 1.0 so a ViewModel ports with a namespace swap. This is **not** a type-forward of sibling families.

## Hosting

```csharp
services.AddMvvmExpress();
services.AddUnoMvvmExpress(configure);
builder.UseUnoMvvmExpress(configure);
options.UseFrameNavigation(configure);
options.UseDialogs();
options.UseAuth<TChallenge>();
```

## Core (shipped)

`ObservableModel`, `ViewModel`, `PageViewModel`, `ModelCommand`, `AsyncModelCommand`, `AsyncState<T>`, `Outcome`, `IMessageHub`, `INavigator`, `IPageNavigator`, `InMemoryNavigator`, `GuardedNavigator`, `IDialogs`, `INotifier`, `IMainThread`, `IWindowContext`, `FormViewModel`, `SectionHostViewModel`, `IAuthState`, `ICache`, `IConnectivityProbe`.

## Hosts (shipped)

- `UnoDispatcherMainThread`
- `UnoWindowContext.For(Window)` / `.Current`
- `ViewModelLifecycle.SetAuto`
- `UnoFrameNavigator.Map<TViewModel, TView>`
- `UnoDialogs` / `UnoNotifier` / `UnoToastPresenter`
- `UnoFormViewModel` (`INotifyDataErrorInfo`)

## Out of 1.0

Shell, `UseDeepLinks`, `UseSecureSessionAuth`, source generators, Reactive, CommunityToolkit compatibility, `NavigateForResultAsync`. IDE extensions are Phase 3.
