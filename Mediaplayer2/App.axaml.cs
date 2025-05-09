using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Mediaplayer2.ViewModels;
using Mediaplayer2.Views;

namespace Mediaplayer2;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Helper.Services();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
            //var vm = new MainWindowViewModel(desktop.MainWindow);
            //desktop.MainWindow.DataContext = vm;
        }

        base.OnFrameworkInitializationCompleted();
    }
}