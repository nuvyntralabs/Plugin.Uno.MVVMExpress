# API parity — Maui 1.3 / WPF 1.0 → Uno Platform

| Surface | Status |
| --- | --- |
| Core ViewModel / commands / AsyncState / Outcome / messenger | Port |
| `INavigator` method surface | Port |
| `UseAuth<TChallenge>` / `GuardedNavigator` | Port |
| Validation / Pagination / Testing | Port |
| `UseWpfMvvmExpress` | Adapt → `UseUnoMvvmExpress` |
| `DispatcherMainThread` | Adapt → `UnoDispatcherMainThread` |
| Lifecycle | Adapt → host attach/detach |
| `WpfFrameNavigator` | Adapt → `UnoFrameNavigator` |
| Dialogs / toasts | Adapt → `UnoDialogs` / overlay |
| `UnoFormViewModel` | Adapt → `INotifyDataErrorInfo` |
| Shell / `UseShell` | Skip |
| `UseDeepLinks` / `UseSecureSessionAuth` | Skip |
| Source generators | Skip |
| Templates | Port — `uno-mvvmexpress` / `uno-mvvmexpress-page` |
| IDE extensions | Skip (Phase 3) |
