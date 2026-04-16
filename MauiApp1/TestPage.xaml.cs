namespace MauiApp1;

public partial class TestPage : ContentPage
{
	string? translatedNumber;

	public TestPage()
	{
		InitializeComponent();
	}

	// Label counterLabel;

	// public TestPage()
	// {
	// 	var myScrollView = new ScrollView();

	// 	var myStackLayout = new VerticalStackLayout();
	// 	myScrollView.Content = myStackLayout;

	// 	counterLabel = new Label
	// 	{
	// 		Text = "Current count: 0",
	// 		FontSize = 18,
	// 		FontAttributes = FontAttributes.Bold,
	// 		HorizontalOptions = LayoutOptions.Center
	// 	};
	// 	myStackLayout.Children.Add(counterLabel);

	// 	var myButton = new Button
	// 	{
	// 		Text = "Click me",
	// 		HorizontalOptions = LayoutOptions.Center
	// 	};
	// 	myStackLayout.Children.Add(myButton);

	// 	myButton.Clicked += OnCounterClicked;

	// 	this.Content = myScrollView;
	// }

	// private void OnCounterClicked(object sender, EventArgs e)
	// {
	// 	count++;
	// 	counterLabel.Text = $"Current count: {count}";

	// 	SemanticScreenReader.Announce(counterLabel.Text);
	// }

	private void OnTranslate(object sender, EventArgs e)
	{
		string enteredNumber = PhoneNumberText.Text;
		translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

		if (!string.IsNullOrEmpty(translatedNumber))
		{
			CallButton.IsEnabled = true;
			CallButton.Text = $"Call {translatedNumber}";
		}
		else
		{
			CallButton.IsEnabled = false;
			CallButton.Text = "Call";

		}
	}

	async void OnCall(object sender, System.EventArgs e)
	{
		if (await this.DisplayAlertAsync(
					"Dial a Number",
					"Would you like to call " + translatedNumber + "?",
					"Yes",
					"No"))
		{
			try
			{
				if (PhoneDialer.Default.IsSupported && !string.IsNullOrWhiteSpace(translatedNumber))
					PhoneDialer.Default.Open(translatedNumber);
			}
			catch (ArgumentNullException)
			{
				await DisplayAlertAsync("Unable to dial", "Phone number was not valid.", "OK");
			}
			catch (Exception)
			{
				// Other error has occurred.
				await DisplayAlertAsync("Unable to dial", "Phone dialing failed.", "OK");
			}
		}
	}
}