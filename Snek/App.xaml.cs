using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snek.Core.Graphs;
using Snek.Core.Repositories;
using Snek.Core.Services;
using Snek.Graph_Creation;
using Snek.Graph_Creation.ViewModel;
using Snek.Infrastructure.Persistence;
using System.IO;
using System.Windows;

namespace Snek;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        var builder = Host.CreateApplicationBuilder();
        var applicationDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Snek");
        var connectionString = $"Data Source={Path.Combine(applicationDirectory, "snek.db")}";

        builder.Services.AddPooledDbContextFactory<SnekDbContext>(options => options.UseSqlite(connectionString));
        builder.Services.AddSingleton<IPosRepository, SqlitePosRepository>();
        builder.Services.AddSingleton<IMitwirkendeService, MitwirkendeService>();
        builder.Services.AddSingleton<IArbeitenService, ArbeitenService>();
        builder.Services.AddSingleton<IZeitenService, ZeitenService>();
        builder.Services.AddSingleton<SeedService>();
        builder.Services.AddSingleton<DatabaseInitializer>();
        builder.Services.AddSingleton<GraphDocumentSerializer>();
        builder.Services.AddSingleton<GraphValueParser>();

        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<UeberUnsViewModel>();
        builder.Services.AddTransient<PosViewModel>();
        builder.Services.AddTransient<Create_Graph_ViewModel>();
        builder.Services.AddTransient<Create_Graph>();

        _host = builder.Build();
    }

    public static T GetRequiredService<T>() where T : notnull =>
        ((App)Current)._host.Services.GetRequiredService<T>();

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        try
        {
            var applicationDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Snek");
            Directory.CreateDirectory(applicationDirectory);

            await _host.StartAsync();
            await _host.Services.GetRequiredService<DatabaseInitializer>().InitializeAsync();
            _host.Services.GetRequiredService<Create_Graph>().Show();
        }
        catch (Exception exception)
        {
            MessageBox.Show(
                $"Snek konnte nicht gestartet werden.{Environment.NewLine}{exception.Message}",
                "Startfehler",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            Shutdown(1);
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync().GetAwaiter().GetResult();
        _host.Dispose();
        base.OnExit(e);
    }
}
