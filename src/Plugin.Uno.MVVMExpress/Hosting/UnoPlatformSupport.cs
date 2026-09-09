namespace Plugin.Uno.MVVMExpress.Hosting;

/// <summary>
/// Window-bound hosts need a platform TFM. Bare <c>net10.0</c> is a shared reference assembly.
/// </summary>
public static class UnoPlatformSupport
{
    /// <summary>True when the current TFM can show a <c>Window</c>.</summary>
    public static bool HasWindowHost =>
#if WINDOWS || __DESKTOP__ || DESKTOP || ANDROID || IOS || MACCATALYST || __WASM__ || BROWSERWASM
        true;
#else
        false;
#endif

    /// <summary>Throws <see cref="NotSupportedException"/> on the bare <c>net10.0</c> TFM.</summary>
    public static void EnsureWindowHost()
    {
        if (!HasWindowHost)
        {
            throw new System.NotSupportedException(
                "Plugin.Uno.MVVMExpress window hosts require a platform TFM (net10.0-desktop, Windows, or a mobile head). The bare net10.0 TFM is a shared reference assembly.");
        }
    }
}
