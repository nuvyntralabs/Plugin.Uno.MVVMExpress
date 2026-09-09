using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Plugin.Uno.MVVMExpress.Hosting;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Threading;

namespace Plugin.Uno.MVVMExpress.Dialogs;

/// <summary>Draws a toast with <see cref="Popup"/> + <see cref="InfoBar"/>. Never replaces <c>Window.Content</c>.</summary>
public sealed class UnoToastPresenter : IToastPresenter
{
    private readonly IWindowContext _window;
    private readonly IMainThread _main;

    public UnoToastPresenter(IWindowContext? window = null, IMainThread? mainThread = null)
    {
        _window = window ?? WindowContext.Default;
        _main = mainThread ?? NotificationMarshaller.Current ?? ImmediateMainThread.Instance;
    }

    public Task ShowAsync(string message, TimeSpan duration, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(message);
        cancellationToken.ThrowIfCancellationRequested();
        return _main.InvokeAsync(() => ShowOnUi(message, duration, cancellationToken), cancellationToken);
    }

    private async Task ShowOnUi(string message, TimeSpan duration, CancellationToken cancellationToken)
    {
        var owner = UnoWindowContext.TryGetWindow(_window);
        if (owner?.Content is not FrameworkElement root || root.XamlRoot is null)
        {
            return;
        }

        var bar = new InfoBar
        {
            Message = message,
            IsOpen = true,
            IsClosable = false,
            Severity = InfoBarSeverity.Informational,
            Width = 320
        };
        var popup = new Popup
        {
            XamlRoot = root.XamlRoot,
            IsHitTestVisible = false,
            Child = bar,
            HorizontalOffset = 24,
            VerticalOffset = 24
        };
        popup.IsOpen = true;
        try
        {
            await Task.Delay(duration, cancellationToken).ConfigureAwait(true);
        }
        finally
        {
            popup.IsOpen = false;
        }
    }
}
