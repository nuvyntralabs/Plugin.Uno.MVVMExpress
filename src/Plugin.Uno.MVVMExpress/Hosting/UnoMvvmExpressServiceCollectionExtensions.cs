using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
#if DEBUG
using Plugin.Uno.MVVMExpress.Diagnostics;
#endif
using Plugin.Uno.MVVMExpress.Generated;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Threading;

namespace Plugin.Uno.MVVMExpress.Hosting;

/// <summary>Uno Platform host entry point.</summary>
public static class UnoMvvmExpressServiceCollectionExtensions
{
    /// <summary>Registers Core plus the family dispatcher, window context, and lifecycle.</summary>
    public static IServiceCollection AddUnoMvvmExpress(
        this IServiceCollection services,
        Action<MvvmExpressOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        var options = new MvvmExpressOptions();
        configure?.Invoke(options);
        return UseUnoMvvmExpress(services, options);
    }

    /// <summary>Registers MVVMExpress on <paramref name="builder"/>.</summary>
    public static IHostApplicationBuilder UseUnoMvvmExpress(
        this IHostApplicationBuilder builder,
        Action<MvvmExpressOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.AddUnoMvvmExpress(configure);
        return builder;
    }

    /// <summary>Registers MVVMExpress on <paramref name="services"/>.</summary>
    public static IServiceCollection UseUnoMvvmExpress(
        this IServiceCollection services,
        Action<MvvmExpressOptions>? configure)
    {
        ArgumentNullException.ThrowIfNull(services);
        var options = new MvvmExpressOptions();
        configure?.Invoke(options);
        return UseUnoMvvmExpress(services, options);
    }

    private static IServiceCollection UseUnoMvvmExpress(IServiceCollection services, MvvmExpressOptions options)
    {
        services.AddSingleton(options);
        services.AddMvvmExpress();
        var main = new UnoDispatcherMainThread();
        services.RemoveAll<IMainThread>();
        services.AddSingleton<IMainThread>(main);
        NotificationMarshaller.Current = main;
        NotificationMarshaller.MarshalNotifications = options.MarshalNotifications;
        services.RemoveAll<IWindowContext>();
        services.AddSingleton<IWindowContext>(_ => UnoWindowContext.Current);
#if DEBUG
        if (options.EnableDiagnostics)
        {
            var diagnostics = new CallbackDiagnostics(static (area, message) =>
                System.Diagnostics.Debug.WriteLine($"[MVVMExpress:{area}] {message}"));
            services.RemoveAll<IMvvmExpressDiagnostics>();
            services.AddSingleton<IMvvmExpressDiagnostics>(_ => diagnostics);
            NotificationMarshaller.Diagnostics = diagnostics;
        }
#endif
        options.ApplyRegistrations(services);
        if (options.ApplyGeneratedRegistrations)
        {
            GeneratedRegistrationHooks.Apply(services);
        }

        if (options.AuthChallengeViewModel is { } challenge)
        {
            services.AddAuth(challenge, options.ForwardNavigationFailures);
        }

        return services;
    }
}
