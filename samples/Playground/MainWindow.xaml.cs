using Microsoft.UI.Xaml;
using Plugin.Uno.MVVMExpress.Hosting;
using Plugin.Uno.MVVMExpress.Navigation;

namespace Plugin.Uno.MVVMExpress.Playground;

public sealed partial class MainWindow : Window
{
    public MainWindow(INavigator navigator, IWindowNavigatorRegistry registry)
    {
        InitializeComponent();
        registry.Register(UnoWindowContext.For(this), navigator);
    }
}
