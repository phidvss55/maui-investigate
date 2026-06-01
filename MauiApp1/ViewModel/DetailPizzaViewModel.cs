using CommunityToolkit.Maui.Core;
using MauiApp1.Pages.Pizza;

namespace MauiApp1.ViewModel;

[QueryProperty(nameof(Pizza), nameof(Pizza))]
public partial class DetailPizzaViewModel: ObservableObject
{
    public DetailPizzaViewModel()
    {
        
    }
    
    [ObservableProperty]
    private Pizza _pizza;
    
    [RelayCommand]
    private void AddToCart()
    {
        Pizza.CartQuantity++;
    }
    
    [RelayCommand]
    private void RemoveFromCart()
    {
        if (Pizza.CartQuantity > 0)
        {
            Pizza.CartQuantity--;
        }
    }

    [RelayCommand]
    private async Task ViewCart()
    {
        if (Pizza.CartQuantity > 0)
        {
            await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
        }
        else
        {
            Toast.Make("Your cart is empty! Please add some pizzas to your cart before viewing it.", ToastDuration.Short).Show();
        }
    }

}