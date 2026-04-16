using System.Diagnostics;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnLoginClicked(object? sender, EventArgs e)
	{
		var button = sender as Button;
		if (button != null)
		{
			button.Text = "Logging in...";
			button.IsEnabled = false;
			Debug.WriteLine("Login button clicked");
		}
	}

	void Button_Clicked(object? sender, EventArgs e)
	{
		DisplayAlertAsync("Alert", "You clicked the button!", "OK");
		Shell.Current.GoToAsync(nameof(FirstPage));
	}
}
