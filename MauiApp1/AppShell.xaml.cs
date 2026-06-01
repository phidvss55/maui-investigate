using MauiApp1.Pages;
using MauiApp1.Pages.Pizza;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
		Routing.RegisterRoute(nameof(FirstPage), typeof(FirstPage));
		
		Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
		Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
		
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(DetailPizzaPage), typeof(DetailPizzaPage));
		Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
	}
}
