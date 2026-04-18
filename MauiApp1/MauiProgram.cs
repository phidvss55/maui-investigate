using MauiApp1.Services;
using MauiApp1.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IMap>(Map.Default);

		builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MonkeyViewModel>();

		builder.Services.AddSingleton<FirstPage>();
		builder.Services.AddSingleton<FirstViewModel>();
		
		builder.Services.AddSingleton<DetailPage>();
		// builder.Services.AddSingleton<DetailViewModel>();
		builder.Services.AddSingleton<MonkeyDetailsViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
