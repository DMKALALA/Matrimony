using Matrimony.ViewModels;

namespace Matrimony;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = ((App)Application.Current).Services.GetService<SignupViewModel>();
    }
}
