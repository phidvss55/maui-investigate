using System.Collections.ObjectModel;
using MauiApp1.Pages.Pizza;

namespace MauiApp1.ViewModel;

[QueryProperty(nameof(FromSearch), nameof(FromSearch))]
public partial class AllPizzaViewModel: ObservableObject
{
    private readonly PizzaService pizzaService;

    public AllPizzaViewModel(PizzaService _pizzaService)
    {
        pizzaService = _pizzaService;
        Pizzas = new (pizzaService.GetAllPizzas());
    }
    
    public ObservableCollection<Pizza> Pizzas { get; set; }
    
    [ObservableProperty]
    private bool _fromSearch;

    [ObservableProperty]
    private bool _searching;

    [RelayCommand]
    private async Task SearchPizzas(string searchTerm)
    {
        Pizzas.Clear();
        Searching = true;
        var queryData = pizzaService.SearchPizzas(searchTerm);
        foreach (var pizza in queryData)
        {
            Pizzas.Add(pizza);
        }
        Searching = false;
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