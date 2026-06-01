using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Pages.Pizza;

namespace MauiApp1.Pages;

public partial class PizzaDashboard : ContentPage
{
    public PizzaDashboard()
    {
        InitializeComponent();
    }

    private async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        // await Shell.Current.GoToAsync($"//{nameof(HomePage)}"); # manual
        await Shell.Current.GoToAsync(nameof(HomePage)); // global::
    }

    private async void OnCancel_OnTapped(object? sender, TappedEventArgs e)
    {
        // back to previous MainPage
        await Shell.Current.GoToAsync("..");
    }
}