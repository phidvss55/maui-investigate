using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModel;

public partial class FirstViewModel : ObservableObject
{
    IConnectivity connectivity;
    public FirstViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }
    
    [ObservableProperty]
    ObservableCollection<string> items;
    
    [ObservableProperty] 
    string text;

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text)) return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No Internet", "You need an internet connection to add items.", "OK");
            return;
        }
            
        Items.Add(Text);
        // add our item
        Text = string.Empty;
    }

    [RelayCommand]
    void Remove(string item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Id={s}");
    }
}