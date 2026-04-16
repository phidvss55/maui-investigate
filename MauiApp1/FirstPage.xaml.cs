using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class FirstPage : ContentPage
{
    public FirstPage(FirstViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}