using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Matrimony.Models;
using Matrimony.Services;

namespace Matrimony.ViewModels;

public partial class GuestViewModel : ObservableObject
{
    private readonly DatabaseService _dBService;

    [ObservableProperty]
    private ObservableCollection<Couples> couples;

    public GuestViewModel(DatabaseService dBService)
    {
        _dBService = dBService;
        couples = new ObservableCollection<Couples>();
    }

    [RelayCommand]
    private async Task SearchAsync(string searchText)
    {
        List<Couples> couplesList = await _dBService.GetCouplesByNameAsync(searchText);
        
        Couples.Clear();
        
        if (couplesList != null)
        {
            foreach (var couple in couplesList)
            {
                Couples.Add(couple);
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Sorry", "There is no couple with that name", "OK");
        }
    }
} 