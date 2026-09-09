using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Plugin.Uno.MVVMExpress.Diagnostics;
using Plugin.Uno.MVVMExpress.Generated;
using Plugin.Uno.MVVMExpress.Hosting;
using Plugin.Uno.MVVMExpress.Threading;

namespace Plugin.Uno.MVVMExpress.Navigation;

public static class MvvmExpressNavigationExtensions
{
    /// <summary>Registers the Frame navigator and <see cref="INavigator"/>.</summary>
    public static MvvmExpressOptions UseFrameNavigation(
        this MvvmExpressOptions options,
        Action<UnoFrameNavigator, IServiceProvider>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        return options.AddRegistration(services =>
        {
            services.RemoveAll<INavigator>();
            services.RemoveAll<IPageNavigator>();
            services.AddSingleton<UnoFrameNavigator>(sp =>
            {
                var window = sp.GetService<IWindowContext>();
                var navigator = new UnoFrameNavigator(
                    window,
                    sp,
                    () => UnoVisualTree.CurrentFrame(window),
                    sp.GetService<IMainThread>(),
                    sp.GetService<IMvvmExpressDiagnostics>(),
                    sp.GetService<MvvmExpressOptions>());
                GeneratedRegistrationHooks.ApplyPageMaps((vm, view, route) => navigator.Map(vm, view, route));
                configure?.Invoke(navigator, sp);
                return navigator;
            });
            services.AddSingleton<IPageNavigator>(sp => sp.GetRequiredService<UnoFrameNavigator>());
            services.AddSingleton<INavigator>(sp => sp.GetRequiredService<UnoFrameNavigator>());
        });
    }
}
