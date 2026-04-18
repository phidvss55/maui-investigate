using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    private IMap map;
    public MonkeyDetailsViewModel(IMap map)
    {
        this.map = map;
    }
    
    [ObservableProperty]
    public partial Monkey Monkey { get; set; }
    
    [RelayCommand]
    async Task OpenMap()
    {
        try
        {
            await this.map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unable to open map: {e.Message}");
            await Shell.Current.DisplayAlertAsync("Error", e.Message, "OK");
        }
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}