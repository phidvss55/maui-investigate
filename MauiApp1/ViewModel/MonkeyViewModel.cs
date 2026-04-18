using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public partial class MonkeyViewModel : BaseViewModel
{
    MonkeyService monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new ObservableCollection<Monkey>();

    public MonkeyViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey";
        this.monkeyService = monkeyService;
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
        if (IsBusy) return;

        try
        {
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
            IsBusy = false;
        }
    }

}