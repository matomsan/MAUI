namespace TabbedPageSample;

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
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
            })
			.ConfigureMauiHandlers(handlers => {
                handlers.AddHandler(typeof(Views.MultiLayerPage), typeof(Handlers.MultiLayerPageHandler));
#if IOS
				handlers.AddHandler(typeof(Views.TabMultiPage), typeof(Handlers.TabMultiPageHandler));
#endif
            })
			;

		return builder.Build();
	}
}
