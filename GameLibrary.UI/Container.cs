using GameLibrary.Application.Repository;
using GameLibrary.Application.Service;
using GameLibrary.Data;
using GameLibrary.Domain.Repository;
using GameLibrary.Domain.Service;
using GameLibrary.UI.Windows;
using StrongInject;

namespace GameLibrary.UI
{
    [RegisterModule(typeof(UIModule))]
    [RegisterModule(typeof(ServiceModule))]
    [RegisterModule(typeof(RepositoryModule))]
    internal partial class Container : IAsyncContainer<SplashWindow>, IAsyncContainer<MainWindow>, IContainer<ILogger>
    {
        [Register(typeof(SplashWindow))]
        [Register(typeof(SplashViewModel))]
        [Register(typeof(MainWindow))]
        [Register(typeof(MainViewModel))]
        [Register(typeof(Logger), Scope.SingleInstance, typeof(ILogger))]
        internal class UIModule { }

        [Register(typeof(GameService), Scope.InstancePerResolution, typeof(IGameService))]
        internal class ServiceModule { }

        [Register(typeof(Context), Scope.SingleInstance)]
        [Register(typeof(GameRepository), Scope.InstancePerResolution, typeof(IGameRepository))]
        internal class RepositoryModule { }
    }
}