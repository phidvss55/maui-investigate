using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public partial class MonkeyViewModel : BaseViewModel
{
    MonkeyService monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new ObservableCollection<Monkey>();

    [ObservableProperty] 
    public partial bool IsRefreshing { get; set; }

    IConnectivity connectivity;
    IGeolocation _geolocation;
    public MonkeyViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
        this.connectivity = connectivity;
        this._geolocation = geolocation;
    }

    [RelayCommand]
    async Task GoToDetail(Monkey monkey)
    {
        if (monkey is null) return;
        
        await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            { "Monkey", monkey }
        });

    }
    
    [RelayCommand]
    async Task GetMonkeys()
    {

        IsRefreshing = true;
        if (IsBusy) return;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlertAsync("No connectivity", "Please check your internet connection and try again.", "OK");
                return;
            }
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();
            if (Monkeys.Count != 0)
                Monkeys.Clear();
            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unable to open map: {e.Message}");
            await Shell.Current.DisplayAlertAsync("Error", e.Message, "OK");
        }
        finally
        {
            IsRefreshing = false;
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GetClosestMonkey()
    {
        if (IsBusy || Monkeys.Count == 0)
        {
            await Shell.Current.DisplayAlertAsync("Please wait", "Monkeys are still loading, please wait a moment.", "OK");
            
        }

        try
        {
            var location = await _geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await _geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy =  GeolocationAccuracy.Medium,
                    Timeout =  TimeSpan.FromSeconds(10)
                });
            }
            
            // find closest monkey to us
            var first = Monkeys.OrderBy(m => location.CalculateDistance(
                new Location(m.Latitude, m.Longitude), DistanceUnits.Miles
            )).FirstOrDefault();

            if (first is null) return;
            
            await Shell.Current.DisplayAlertAsync("", first.Name + " " + first.Location, "OK");
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unable to open map: {e.Message}");
            await Shell.Current.DisplayAlertAsync("Error", e.Message, "OK");
        }
    }

}