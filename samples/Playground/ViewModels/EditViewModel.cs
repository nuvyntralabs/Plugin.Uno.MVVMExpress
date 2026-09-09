using Plugin.Uno.MVVMExpress.Dialogs;
using Plugin.Uno.MVVMExpress.Forms;
using Plugin.Uno.MVVMExpress.Input;
using Plugin.Uno.MVVMExpress.Navigation;
using Plugin.Uno.MVVMExpress.Outcome;

namespace Plugin.Uno.MVVMExpress.Playground.ViewModels;

public sealed class EditViewModel : UnoFormViewModel
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
        await Task.Delay(80, cancellationToken).ConfigureAwait(true);
        MarkClean();
        await Dialogs!.AlertAsync("Saved", "The item is stored.", cancellationToken: cancellationToken).ConfigureAwait(true);
    }

    protected override Task<IReadOnlyList<ValidationMessage>> CollectErrorsAsync(CancellationToken cancellationToken)
    {
        IReadOnlyList<ValidationMessage> messages = string.IsNullOrWhiteSpace(Name)
            ? [new ValidationMessage(nameof(Name), "Name is required.")]
            : [];
        return Task.FromResult(messages);
    }
}
