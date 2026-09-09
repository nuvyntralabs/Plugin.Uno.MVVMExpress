using Plugin.Uno.MVVMExpress.ComponentModel;
using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Input;
using Plugin.Uno.MVVMExpress.Navigation;

namespace App1;

public sealed record DetailsArgs(string Title);

public sealed class DetailsViewModel : PageViewModel, IAcceptNavArgs<DetailsArgs>
{
    private string _title = "Details";

    public DetailsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {
        BackCommand = new AsyncModelCommand(ct => Navigator!.GoBackAsync(ct));
    }

    public string Title
    {
        get => _title;
        private set => SetProperty(ref _title, value);
    }

    public AsyncModelCommand BackCommand { get; }

    public void Accept(DetailsArgs args) => Title = args.Title;
}
