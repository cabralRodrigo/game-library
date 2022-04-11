using GameLibrary.UI.Windows;
using System.Reflection;
using System.Windows;

namespace GameLibrary.UI
{
    public partial class App : System.Windows.Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new Container();
            var logger = container.Resolve().Value;

            var (version, commit) = GetVersion();
            logger.Info("Initializing version {version} ({commit})", version, commit);

            var splash = (await container.ResolveAsync<SplashWindow>()).Value;
            this.MainWindow = splash;
            this.MainWindow.Show();

            await ((SplashViewModel)this.MainWindow.DataContext).MigrateDatabase();

            this.MainWindow = (await container.ResolveAsync<MainWindow>()).Value;
            this.MainWindow.Show();
            splash.Close();

            logger.Info("Initializion complete");
            this.Exit += (_, _) => logger.Info("Exiting");
        }

        private static (string? Version, string? Commit) GetVersion()
        {
            var assembly = typeof(App).Assembly;
            var info = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            var name = assembly.GetName();

            if (info?.InformationalVersion is not null)
            {
                var parts = info.InformationalVersion.Split('+');
                if (parts.Length == 2)
                    return (name.Version?.ToString(), parts[1]);
            }

            return (name.Version?.ToString(), null);

        }
    }
}