using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaNavigation.Navigation;
using AvaloniaNavigation.ViewModels;
using AvaloniaNavigation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaNavigation;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit.
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();

            // Configure the DI container
            var services = new ServiceCollection();
            ConfigureServices(services);
            Services = services.BuildServiceProvider();

            desktop.MainWindow = new MainWindow
            {
                DataContext = Services.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register page ViewModels — order matters for navigation
        services.AddTransient<FirstPageViewModel>();
        services.AddTransient<SecondPageViewModel>();
        services.AddTransient<ThirdPageViewModel>();

        // Register NavigationService as singleton so state is preserved
        services.AddSingleton<NavigationService>(sp =>
        {
            var pages = new PageViewModelBase[]
            {
                sp.GetRequiredService<FirstPageViewModel>(),
                sp.GetRequiredService<SecondPageViewModel>(),
                sp.GetRequiredService<ThirdPageViewModel>()
            };
            return new NavigationService(pages);
        });

        // Register MainWindowViewModel
        services.AddTransient<MainWindowViewModel>();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}
