using Microsoft.Extensions.DependencyInjection;
using Plugin.Uno.MVVMExpress.Collections;
using Plugin.Uno.MVVMExpress.ComponentModel;
using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Input;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Pagination;
using Plugin.Uno.MVVMExpress.Playground;

namespace Plugin.Uno.MVVMExpress.Playground.ViewModels;

public sealed class HomeViewModel : PageViewModel
{
    private int _count;
    private readonly IServiceProvider _services;

    public HomeViewModel(INavigator navigator, IDialogs dialogs, INotifier notifier, IServiceProvider services)
        : base(navigator, dialogs)
    {
        _services = services;
        IncrementCommand = new AsyncModelCommand(IncrementAsync);
        OpenDetailsCommand = new AsyncModelCommand(OpenDetailsAsync);
        OpenEditCommand = new AsyncModelCommand(ct => Navigator!.NavigateToAsync<EditViewModel>(ct));
        ToastCommand = new AsyncModelCommand(ct => notifier.ToastAsync("Saved", cancellationToken: ct));
        OpenWindowCommand = new ModelCommand(OpenSecondWindow);
        Items = new SnapshotCollection<string>(ct => Task.FromResult<IReadOnlyList<string>>(["Latte", "Mocha", "Espresso"]));
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
    public ModelCommand OpenWindowCommand { get; }

    public override Task InitializeAsync(CancellationToken cancellationToken = default)
        => Items.LoadAsync(false, cancellationToken);

    private async Task IncrementAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(80, cancellationToken).ConfigureAwait(true);
        Count++;
    }

    private Task OpenDetailsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DetailsViewModel, DetailsArgs>(new DetailsArgs("Latte"), cancellationToken);

    private void OpenSecondWindow()
        => _services.GetRequiredService<SecondaryWindow>().Activate();
}

public sealed record DetailsArgs(string Title);
