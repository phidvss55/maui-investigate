namespace MauiApp1.Pages.Pizza;

public partial class HomePage : ContentPage
{
    private readonly PizzaHomeViewModel _viewModel;
    public HomePage(PizzaHomeViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}
