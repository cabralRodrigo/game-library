using GameLibrary.UI.Windows;
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
            logger.Info("Initializing");

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
    }
}