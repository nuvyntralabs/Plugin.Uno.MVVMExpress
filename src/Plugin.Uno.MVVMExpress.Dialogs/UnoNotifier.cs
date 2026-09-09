using Plugin.Uno.MVVMExpress.Navigation;

namespace Plugin.Uno.MVVMExpress.Dialogs;

/// <summary><see cref="INotifier"/> that shows an overlay toast.</summary>
public sealed class UnoNotifier : INotifier
{
    private readonly IToastPresenter _presenter;

    public UnoNotifier(IToastPresenter? presenter = null, IWindowContext? window = null)
        => _presenter = presenter ?? new UnoToastPresenter(window);

    public Task ToastAsync(string message, TimeSpan? duration = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(message);
        cancellationToken.ThrowIfCancellationRequested();
        return _presenter.ShowAsync(message, duration ?? TimeSpan.FromSeconds(2), cancellationToken);
    }
}
