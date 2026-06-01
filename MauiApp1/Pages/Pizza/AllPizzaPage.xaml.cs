using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Pages.Pizza;

public partial class AllPizzaPage : ContentPage
{
    private readonly AllPizzaViewModel _viewModel;
    
    public AllPizzaPage(AllPizzaViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel.FromSearch)
        {
            await Task.Delay(100);
            searchBar.Focus();
        }
    }

    private void SearchBar_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.OldTextValue) && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _viewModel.SearchPizzasCommand.Execute(null);
        }
    }
}