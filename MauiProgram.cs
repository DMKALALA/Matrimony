using System.IO;
using Matrimony;
using Matrimony.Services;
using Matrimony.ViewModels;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // Register your app and inject service provider into App
        builder.UseMauiApp<App>(provider => new App(provider))
               .ConfigureFonts(fonts =>
               {
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
               });

        // Register app-wide services
        builder.Services.AddSingleton(s =>
            new DatabaseService(Path.Combine(FileSystem.AppDataDirectory, "matrimony.db")));

        // Register ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<SignupViewModel>();
        builder.Services.AddTransient<MainViewModel>();

        return builder.Build();
    }
}
