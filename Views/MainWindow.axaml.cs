using Avalonia.Controls;

namespace rdp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        CanResize = false;
        Width = 1920;
        Height = 1080;
    }

}
