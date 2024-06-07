using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using rdp.Classes;
using Avalonia.Media.Imaging;
using System.Threading.Tasks;
using System.Threading;


namespace rdp.ViewModels;

public class MainViewModel : ViewModelBase
{
    //public Bitmap Screenshot { get; set => this.RaiseAndSetIfChanged(ref ); }

    private Bitmap _Screenshot;

    public Bitmap Screenshot
    {
        get { return _Screenshot; }
        set => this.RaiseAndSetIfChanged(ref _Screenshot, value);
    }

    public Timer timer;

    public ReactiveCommand<object, Unit> reactiveCommand { get; }
    
    public MainViewModel() 
    {
        timer = new Timer(GetImage, null, 0, 10);
        reactiveCommand = ReactiveCommand.Create<object>(GetImage);
        
    }

    public void GetImage(object state)
    {
        Screenshot = Capturer.CaptureImage();
    }
}