using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel;

public partial class CartViewModel: ObservableObject
{
    public CartViewModel()
    {
        
    }
    
    public ObservableCollection<Pizza> Items { get; set; }

    [ObservableProperty]
    private double _totalAmount;
    
    private void ReCalculateTotalAmount()
    {
        TotalAmount = Items.Sum(i => i.Amount);
    }

    [RelayCommand]
    private void UpdateCartItem(Pizza pizza)
    {
        var item = Items.FirstOrDefault(i => i.Name == pizza.Name);
        if (item != null)
        {
            item.CartQuantity = pizza.CartQuantity;
            if (item.CartQuantity == 0)
            {
                Items.Remove(item);
            }
        }
        else
        {
            Items.Add(pizza.Clone());
        }

        ReCalculateTotalAmount();
    }
    
    [RelayCommand]
    private void RemoveCartItem(string name)
    {
        var item = Items.FirstOrDefault(i => i.Name == name);
        if (item != null)
        {
            Items.Remove(item);
        }
        ReCalculateTotalAmount();
    }
    
    [RelayCommand]
    private async void ClearCart()
    {
        if (await Shell.Current.DisplayAlertAsync("Confirm Clear Cart", "Are you sure you want to clear your cart?", "Yes", "No"))
        {
            Items.Clear();
            ReCalculateTotalAmount();
            await Toast.Make("Cart cleared successfully!", ToastDuration.Short).Show();
        }
    }
    
    [RelayCommand]
    private async void Checkout()
    {
        if (Items.Count == 0)
        {
            await Toast.Make("Your cart is empty! Please add some pizzas to your cart before checking out.", ToastDuration.Short).Show();
            return;
        }
        
        await Task.Delay(2000); // Simulate checkout processing time
        
        // Implement checkout logic here (e.g., navigate to a checkout page, process payment, etc.)
        await Toast.Make("Checkout successful! Thank you for your order.", ToastDuration.Short).Show();
        Items.Clear();
        ReCalculateTotalAmount();
        
        // go to checkout page
    }
}