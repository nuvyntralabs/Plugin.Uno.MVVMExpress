using Microsoft.UI.Xaml;
using Plugin.Uno.MVVMExpress.Hosting;

namespace Plugin.Uno.MVVMExpress.Playground;

public sealed partial class SecondaryWindow : Window
{
    public SecondaryWindow()
    {
        InitializeComponent();
        UnoWindowContext.For(this);
    }
}
