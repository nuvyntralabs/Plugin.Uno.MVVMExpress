# Known limitations — Plugin.Uno.MVVMExpress 1.0

- Do not PackageReference `Plugin.WinUI.MVVMExpress.*`. This is an independent Uno family.
- Bare `net10.0` is a shared reference assembly. Window hosts throw `NotSupportedException` there. Use `net10.0-desktop` or a Windows / mobile head.
- 1.0 Playground and template target Skia desktop. WinAppSDK, Android, iOS, and WASM are best-effort heads, not SemVer-blocking.
- Mobile multi-window is hidden. WASM toasts/dialogs are best-effort.
- No Uno.Extensions.Navigation wrapper.
- Toasts overlay the tree and never replace `Window.Content`.
- Source generators, Reactive, CommunityToolkit compatibility, `UseDeepLinks`, and `UseSecureSessionAuth` are out of 1.0.
