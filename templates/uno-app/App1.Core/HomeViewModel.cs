using Plugin.Uno.MVVMExpress.Collections;
using Plugin.Uno.MVVMExpress.ComponentModel;
using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Input;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Pagination;

namespace App1;

public sealed class HomeViewModel : PageViewModel
{
    private int _count;

    public HomeViewModel(INavigator navigator, IDialogs dialogs, INotifier notifier, IItemStore store)
        : base(navigator, dialogs)
    {
        ArgumentNullException.ThrowIfNull(store);
        IncrementCommand = new AsyncModelCommand(IncrementAsync);
        OpenDetailsCommand = new AsyncModelCommand(ct =>
            Navigator!.NavigateToAsync<DetailsViewModel, DetailsArgs>(new DetailsArgs("Latte"), ct));
        OpenEditCommand = new AsyncModelCommand(ct => Navigator!.NavigateToAsync<EditViewModel>(ct));
        ToastCommand = new AsyncModelCommand(ct => notifier.ToastAsync("Saved", cancellationToken: ct));
        Items = new SnapshotCollection<string>(store.ListAsync);
        RefreshCommand = new AsyncModelCommand(ct => Items.LoadAsync(false, ct));
    }

    public int Count
    {
        get => _count;
        private set => SetProperty(ref _count, value);
    }

    public SnapshotCollection<string> Items { get; }

    public ObservableRangeCollection<string> Catalog => Items.Items;

    public AsyncModelCommand IncrementCommand { get; }

    public AsyncModelCommand OpenDetailsCommand { get; }

    public AsyncModelCommand OpenEditCommand { get; }

    public AsyncModelCommand ToastCommand { get; }

    public AsyncModelCommand RefreshCommand { get; }

    public override Task InitializeAsync(CancellationToken cancellationToken = default)
        => Items.LoadAsync(false, cancellationToken);

    private async Task IncrementAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(40, cancellationToken).ConfigureAwait(true);
        Count++;
    }
}
