# Plugin.Uno.MVVMExpress.Dialogs

`UnoDialogs` adapts `IDialogs` to `ContentDialog`. `UnoNotifier` uses `Popup` + `InfoBar` and never wraps `Window.Content`.

```csharp
o.UseDialogs();
await Dialogs.AlertAsync("Saved", "The item is stored.");
await notifier.ToastAsync("Saved");
```

ViewModels must not call `ContentDialog` directly. Use `IDialogs` / `INotifier`.

License: MIT.
