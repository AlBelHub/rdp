using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using rdp.Classes;
using System.Diagnostics;
using System.Threading.Tasks;


namespace rdp.Views;

public partial class MainView : UserControl
{


    public MainView()
    {
        InitializeComponent();
    }

    public void ExitHandler(object sender, RoutedEventArgs args)
    {
        if (Application.Current?.ApplicationLifetime 
            is 
            IClassicDesktopStyleApplicationLifetime 
            lifetime) lifetime.Shutdown();
    }
}
