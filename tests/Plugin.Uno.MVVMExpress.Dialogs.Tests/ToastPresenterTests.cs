using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Threading;

namespace Plugin.Uno.MVVMExpress.Dialogs.Tests;

public sealed class ToastPresenterTests
{
    [Fact]
    public async Task Toast_WithoutOwnerWindow_DoesNotThrow()
    {
        var presenter = new UnoToastPresenter(WindowContext.Default, ImmediateMainThread.Instance);
        await presenter.ShowAsync("Saved", TimeSpan.FromMilliseconds(1));
    }
}
