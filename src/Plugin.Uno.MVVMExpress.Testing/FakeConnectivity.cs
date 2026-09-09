using Plugin.Uno.MVVMExpress.Connectivity;

namespace Plugin.Uno.MVVMExpress.Testing;

/// <summary>Mutable <see cref="IConnectivityProbe"/> for ViewModel tests.</summary>
public sealed class FakeConnectivity : IConnectivityProbe
{
    /// <inheritdoc />
    public bool IsOnline { get; set; } = true;
}
