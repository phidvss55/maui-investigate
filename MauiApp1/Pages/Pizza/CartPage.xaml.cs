using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Pages.Pizza;

public partial class CartPage : ContentPage
{
    private readonly CartViewModel _viewModel;
    public CartPage(CartViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}