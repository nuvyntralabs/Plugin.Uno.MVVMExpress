using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Forms;
using Plugin.Uno.MVVMExpress.Input;
using Plugin.Uno.MVVMExpress.Navigation;

namespace App1;

public sealed class EditViewModel : FormViewModel
{
    private readonly FormField<string> _name;

    public EditViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {
        _name = Field("Name", "");
        Bind(_name, nameof(Name), () => SaveCommand.NotifyCanExecuteChanged());
        SaveCommand = new AsyncModelCommand(SaveAsync, () => !string.IsNullOrWhiteSpace(Name));
        BackCommand = new AsyncModelCommand(ct => Navigator!.GoBackAsync(ct));
    }

    public string Name
    {
        get => _name.Value ?? "";
        set => _name.Value = value;
    }

    public AsyncModelCommand SaveCommand { get; }

    public AsyncModelCommand BackCommand { get; }

    private async Task SaveAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(40, cancellationToken).ConfigureAwait(true);
        MarkClean();
        await Dialogs!.AlertAsync("Saved", "The item is stored.", cancellationToken: cancellationToken).ConfigureAwait(true);
    }
}
