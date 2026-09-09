using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Plugin.Uno.MVVMExpress.Hosting;

namespace Plugin.Uno.MVVMExpress.Dialogs;

public static class MvvmExpressDialogsExtensions
{
    public static MvvmExpressOptions UseDialogs(this MvvmExpressOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        return options.AddRegistration(static services =>
        {
            services.RemoveAll<IDialogs>();
            services.RemoveAll<INotifier>();
            services.AddSingleton<IDialogs, UnoDialogs>();
            services.AddSingleton<INotifier, UnoNotifier>();
        });
    }
}
