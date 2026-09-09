using Microsoft.Extensions.DependencyInjection;
using Plugin.Uno.MVVMExpress.Caching;
using Plugin.Uno.MVVMExpress.Composition;
using Plugin.Uno.MVVMExpress.Connectivity;
using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Files;
using Plugin.Uno.MVVMExpress.Flags;
using Plugin.Uno.MVVMExpress.Hosting;
using Plugin.Uno.MVVMExpress.Media;
using Plugin.Uno.MVVMExpress.Messaging;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Operations;
using Plugin.Uno.MVVMExpress.Permissions;
using Plugin.Uno.MVVMExpress.Threading;

namespace Plugin.Uno.MVVMExpress.Core.Tests.Hosting;

public sealed class AddMvvmExpressTests
{
    [Fact]
    public void AddMvvmExpress_RegistersCoreSingletons()
    {
        using var provider = new ServiceCollection().AddMvvmExpress().BuildServiceProvider();
        Assert.IsType<MessageHub>(provider.GetRequiredService<IMessageHub>());
        Assert.IsType<MemoryCache>(provider.GetRequiredService<ICache>());
        Assert.IsType<InMemoryConnectivityProbe>(provider.GetRequiredService<IConnectivityProbe>());
        var navigator = Assert.IsType<InMemoryNavigator>(provider.GetRequiredService<INavigator>());
        Assert.Same(navigator, provider.GetRequiredService<IPageNavigator>());
        Assert.Same(ImmediateMainThread.Instance, provider.GetRequiredService<IMainThread>());
        Assert.IsType<NullDialogs>(provider.GetRequiredService<IDialogs>());
        Assert.Same(NullDialogs.Instance, provider.GetRequiredService<INotifier>());
        Assert.Equal("default", provider.GetRequiredService<IWindowContext>().WindowId);
        Assert.IsType<WindowNavigatorRegistry>(provider.GetRequiredService<IWindowNavigatorRegistry>());
        Assert.IsType<CachedFetcher>(provider.GetRequiredService<ICachedFetcher>());
        Assert.IsType<OperationExecutor>(provider.GetRequiredService<IOperationExecutor>());
        Assert.IsType<ServiceViewModelScopeFactory>(provider.GetRequiredService<IViewModelScopeFactory>());
        Assert.IsType<MemoryFeatureSwitch>(provider.GetRequiredService<IFeatureSwitch>());
        Assert.Same(AllowAllPermissionGate.Instance, provider.GetRequiredService<IPermissionGate>());
        Assert.IsType<MemoryFileStore>(provider.GetRequiredService<IFileStore>());
        Assert.Same(NullMediaPicker.Instance, provider.GetRequiredService<IMediaPicker>());
    }
}
