using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Toolbox.Core;

namespace Toolbox.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Configuration.AddAppSettings();
        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<ICommandService, CommandService>();

        return builder.Build();
    }
}

public static class Extensions
{
    public static IConfigurationBuilder AddAppSettings(this IConfigurationBuilder configurationBuilder)
    {
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("Toolbox.UI.appsettings.json");
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        configurationBuilder.AddConfiguration(config);

        return configurationBuilder;
    }
}