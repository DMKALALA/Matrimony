using Matrimony.ViewModels;

namespace Matrimony.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = ((App)Application.Current).Services.GetService<SignupViewModel>();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignupPage");
    }
}
