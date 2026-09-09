using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Plugin.Uno.MVVMExpress.Busy;
using Plugin.Uno.MVVMExpress.Caching;
using Plugin.Uno.MVVMExpress.Composition;
using Plugin.Uno.MVVMExpress.Connectivity;
using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Errors;
using Plugin.Uno.MVVMExpress.Files;
using Plugin.Uno.MVVMExpress.Flags;
using Plugin.Uno.MVVMExpress.Media;
using Plugin.Uno.MVVMExpress.Messaging;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Operations;
using Plugin.Uno.MVVMExpress.Permissions;
using Plugin.Uno.MVVMExpress.Diagnostics;
using Plugin.Uno.MVVMExpress.State;
using Plugin.Uno.MVVMExpress.Threading;

namespace Plugin.Uno.MVVMExpress.Hosting;

/// <summary>Registers Core services for tests, samples, and <c>UseMvvmExpress</c>.</summary>
public static class MVVMExpressServiceCollectionExtensions
{
    /// <summary>Adds Core singletons used by ViewModels.</summary>
    /// <param name="services">Service collection.</param>
    public static IServiceCollection AddMvvmExpress(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.TryAddSingleton<IMessageHub, MessageHub>();
        services.TryAddSingleton<IBusyGate, BusyGate>();
        services.TryAddSingleton<IErrorSink, NullErrorSink>();
        services.TryAddSingleton<ICache, MemoryCache>();
        services.TryAddSingleton<IConnectivityProbe, InMemoryConnectivityProbe>();
        services.TryAddSingleton<IWindowContext>(_ => WindowContext.Default);
        services.TryAddSingleton<IWindowNavigatorRegistry, WindowNavigatorRegistry>();
        services.TryAddSingleton<InMemoryNavigator>();
        services.TryAddSingleton<INavigator>(sp => sp.GetRequiredService<InMemoryNavigator>());
        services.TryAddSingleton<IPageNavigator>(sp => sp.GetRequiredService<InMemoryNavigator>());
        services.TryAddSingleton<IMainThread>(_ => ImmediateMainThread.Instance);
        services.TryAddSingleton<IDialogs, NullDialogs>();
        services.TryAddSingleton<INotifier>(_ => NullDialogs.Instance);
        services.TryAddSingleton<ICachedFetcher>(sp =>
            new CachedFetcher(sp.GetRequiredService<ICache>(), sp.GetService<IConnectivityProbe>()));
        services.TryAddSingleton<IOperationExecutor>(sp =>
            new OperationExecutor(sp.GetService<IBusyGate>(), sp.GetService<IErrorSink>()));
        services.TryAddSingleton<IViewModelScopeFactory>(sp => new ServiceViewModelScopeFactory(sp));
        services.TryAddSingleton<IFeatureSwitch, MemoryFeatureSwitch>();
        services.TryAddSingleton<IPermissionGate>(_ => AllowAllPermissionGate.Instance);
        services.TryAddSingleton<IFileStore, MemoryFileStore>();
        services.TryAddSingleton<IMediaPicker>(_ => NullMediaPicker.Instance);
        services.TryAddSingleton<IStateStore, MemoryStateStore>();
        services.TryAddSingleton<IMvvmExpressDiagnostics>(_ => NullDiagnostics.Instance);
        return services;
    }
}
