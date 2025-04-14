namespace Matrimony;

public partial class App : Application
{
    public IServiceProvider Services { get; }

    public App(IServiceProvider services)
    {
        InitializeComponent();
        Services = services;
        MainPage = new AppShell(); // Assumes you have AppShell.xaml
    }
}
