using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Popups.ViewModels;
using Popups.Views;

namespace Popups;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<Pages.MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();

		PopupService.RegisterPopup<ConfirmationPopupView, ConfirmationPopupViewModel>(builder.Services);
        builder.Services.AddSingleton<PopupService>();

        return builder.Build();
	}
}
