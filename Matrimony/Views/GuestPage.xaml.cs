using System.Collections.ObjectModel;
using Matrimony.Models;
using Matrimony.Services;
using Matrimony.ViewModels;

namespace Matrimony.Views;

public partial class GuestPage : ContentPage
{
    private readonly DatabaseService _dBService;
    private ObservableCollection<Couples> _couples;
    public ObservableCollection<Couples> Couples 
    { 
        get => _couples;
        set
        {
            if (_couples != value)
            {
                _couples = value;
                OnPropertyChanged(nameof(Couples));
            }
        }
    }

    public GuestPage()
    {
        InitializeComponent();
        _dBService = ((App)Application.Current).Services.GetService<DatabaseService>();
        BindingContext = new GuestViewModel(_dBService);
        
        // Enable back button
        NavigationPage.SetHasBackButton(this, true);
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//LoginPage");
        return true;
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        string searchText = SearchBar.Text;
        List<Couples> couplesList = await _dBService.GetCouplesByNameAsync(searchText);
        
        Couples.Clear();
        
        if (couplesList != null)
        {
            foreach (var couple in couplesList)
            {
                Couples.Add(couple);
            }
        } else
        {
            await DisplayAlert("Sorry", "There is no couple with that name", "OK");
        }
    }

    private async void OnAcceptClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int coupleId)
        {
            await _dBService.UpdateCoupleRSVPAsync(coupleId, true);
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }

    private async void OnDeclineClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int coupleId)
        {
            await _dBService.UpdateCoupleRSVPAsync(coupleId, false);
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
} 