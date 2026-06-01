using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if IOS
using UIKit;
#endif

namespace MauiApp1.Pages.Pizza;

public partial class DetailPizzaPage : ContentPage
{
    private readonly DetailPizzaViewModel _viewModel;
    public DetailPizzaPage(DetailPizzaViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
#if IOS
        var bottom = UIKit.UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;
        var data = new Thickness(-1, 0, -1, (bottom + 1) * -1);
        bottomBox.Margin = data;
#endif
    }

    private async void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", animate: true);
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
        Behaviors.Add(new CommunityToolkit.Maui.Behaviors.StatusBarBehavior
        {
            StatusBarColor = Colors.DarkGoldenrod, 
            StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent
        });
    }
}