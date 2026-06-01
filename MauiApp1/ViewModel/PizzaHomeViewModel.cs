using System.Collections.ObjectModel;
using MauiApp1.Pages.Pizza;

namespace MauiApp1.ViewModel;

public partial class PizzaHomeViewModel: ObservableObject
{
    private readonly PizzaService _pizzaService;
    public PizzaHomeViewModel(PizzaService pizzaService)
    {
        _pizzaService = pizzaService;
        Pizzas = new(_pizzaService.GetAllPizzas());
    }
    
    public ObservableCollection<Pizza> Pizzas { get; set; }
    
    [RelayCommand]
    private async Task GoToAllPizzasPage(bool fromSearch = false)
    {
        var parameters = new Dictionary<string, object>
        {
            [nameof(AllPizzaViewModel.FromSearch)] = fromSearch,
        };
        await Shell.Current.GoToAsync(nameof(AllPizzaPage), animate: true, parameters);
    }
    
    [RelayCommand]
    private async Task GoToDetailPage(Pizza pizza)
    {
        var parameters = new Dictionary<string, object>
        {
            [nameof(DetailPizzaViewModel.Pizza)] = pizza
        };
        await Shell.Current.GoToAsync(nameof(DetailPizzaPage), animate: true, parameters);
    }
}