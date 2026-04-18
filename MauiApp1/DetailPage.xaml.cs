using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class DetailPage : ContentPage
{
    public DetailPage(MonkeyDetailsViewModel detail)
    {
        InitializeComponent();
        BindingContext = detail;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}