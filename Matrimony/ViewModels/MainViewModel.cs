using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

namespace Matrimony.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string greeting = $"Welcome, {Preferences.Get("Username", "Guest")}!";

    [RelayCommand]
    private async Task LogoutAsync()
    {
        Preferences.Set("IsLoggedIn", false);
        Preferences.Remove("Username");

        await Shell.Current.GoToAsync("//LoginPage");
    }
}
