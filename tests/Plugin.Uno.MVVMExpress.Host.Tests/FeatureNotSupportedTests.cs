using Plugin.Uno.MVVMExpress.Hosting;

namespace Plugin.Uno.MVVMExpress.Host.Tests;

public sealed class FeatureNotSupportedTests
{
    [Fact]
    public void WindowContext_For_Throws_On_Bare_Net10()
    {
        Assert.Throws<NotSupportedException>(() => UnoPlatformSupport.EnsureWindowHost());
    }
}
