using GameLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.UI.Windows
{
    public partial class SplashViewModel : ViewModel
    {
        [Notify]
        private string message = default!;

        private readonly Context context;
        private readonly ILogger logger;

        public SplashViewModel(Context context, ILogger logger)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Message = Strings.Splash_VerifyingDatabase;
        }

        public async Task MigrateDatabase()
        {
            this.logger.Info("Verifying database version");

            var migrations = (await this.context.Database.GetPendingMigrationsAsync()).ToArray();
            if (migrations.Length <= 0)
            {
                this.logger.Info("The database is up to date");
                return;
            }

            this.logger.Info("Updating database. Applying migrations: {migrations}", migrations);
            this.Message = Strings.Splash_UpdatingDatabase;
            await this.context.Database.MigrateAsync();

            this.logger.Info("Database update finished");
            this.Message = Strings.Splash_Finished;
        }
    }
}