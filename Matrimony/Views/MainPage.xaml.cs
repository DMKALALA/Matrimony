using Matrimony.ViewModels;

namespace Matrimony.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = ((App)Application.Current).Services.GetService<MainViewModel>();
    }
}
