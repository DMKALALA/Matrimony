using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Matrimony.Services;

namespace Matrimony.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly DatabaseService _db;

    [ObservableProperty] private string email;
    [ObservableProperty] private string password;

    public LoginViewModel(DatabaseService db)
    {
        _db = db;
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        var user = await _db.GetUserAsync(Email, Password);
        if (user != null)
        {
            await Shell.Current.DisplayAlert("Welcome", $"Hello {user.Username}", "OK");
            await Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            await Shell.Current.DisplayAlert("Login Failed", "Invalid credentials", "Try Again");
        }
    }
}
