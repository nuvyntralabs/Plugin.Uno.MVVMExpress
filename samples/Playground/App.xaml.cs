using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using Plugin.Uno.MVVMExpress.Auth;
using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Hosting;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Playground.Pages;
using Plugin.Uno.MVVMExpress.Playground.Services;
using Plugin.Uno.MVVMExpress.Playground.ViewModels;

namespace Plugin.Uno.MVVMExpress.Playground;

public partial class App : Application
{
    private IHost? _host;

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<IAuthState, DemoAuthState>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<DetailsViewModel>();
        builder.Services.AddTransient<EditViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<EditPage>();
        builder.Services.AddSingleton<MainWindow>();
        builder.Services.AddTransient<SecondaryWindow>();
        builder.Services.UseUnoMvvmExpress(o => o
            .UseFrameNavigation((nav, _) => nav
                .Map<LoginViewModel, LoginPage>("login")
                .Map<HomeViewModel, HomePage>("home")
                .Map<DetailsViewModel, DetailsPage>("details")
                .Map<EditViewModel, EditPage>("edit"))
            .UseDialogs()
            .UseAuth<LoginViewModel>());

        _host = builder.Build();
        await _host.StartAsync().ConfigureAwait(true);

        var window = _host.Services.GetRequiredService<MainWindow>();
        UnoWindowContext.MainWindow = window;
        window.Activate();

        var navigator = _host.Services.GetRequiredService<INavigator>();
        await navigator.ResetAsync<LoginViewModel>().ConfigureAwait(true);
    }
}
