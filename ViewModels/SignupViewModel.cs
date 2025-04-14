using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Matrimony.Models;
using Matrimony.Services;

namespace Matrimony.ViewModels;

public partial class SignupViewModel : ObservableObject
{
    private readonly DatabaseService _db;

    [ObservableProperty] private string username;
    [ObservableProperty] private string email;
    [ObservableProperty] private string password;

    public SignupViewModel(DatabaseService db)
    {
        _db = db;
    }

    [RelayCommand]
    private async Task SignupAsync()
    {
        var user = new User { Username = Username, Email = Email, Password = Password };
        await _db.AddUserAsync(user);
        await Shell.Current.DisplayAlert("Success", "Account created!", "OK");
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
