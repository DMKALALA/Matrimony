using Matrimony.ViewModels;

namespace Matrimony.Views;

public partial class SignupPage : ContentPage
{
    public SignupPage()
    {
        InitializeComponent();
        BindingContext = ((App)Application.Current).Services.GetService<SignupViewModel>();
    }
}
