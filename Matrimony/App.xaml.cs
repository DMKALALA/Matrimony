namespace Matrimony;

public partial class App : Application
{
    public IServiceProvider Services { get; }

    public App(IServiceProvider services)
    {
        InitializeComponent();
        Services = services;
        MainPage = new AppShell();
        
        // Set the initial route to MainPage
        //Shell.Current.GoToAsync("//MainPage");
    }
}
