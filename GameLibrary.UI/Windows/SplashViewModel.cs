using GameLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.UI.Windows
{
    public partial class SplashViewModel : ViewModel
    {
        [Notify]
        private string message = default!;

        private readonly Context context;

        public SplashViewModel(Context context)
        {
            this.Message = Strings.Splash_VerifyingDatabase;
            this.context = context;
        }

        public async Task MigrateDatabase()
        {
            var migrations = (await this.context.Database.GetPendingMigrationsAsync()).ToArray();
            if (migrations.Length <= 0)
                return;

            this.Message = Strings.Splash_UpdatingDatabase;
            await this.context.Database.MigrateAsync();

            this.Message = Strings.Splash_Finished;
        }
    }
}