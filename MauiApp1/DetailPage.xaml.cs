using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel detail)
    {
        InitializeComponent();
        BindingContext = detail;
    }
}