using GameLibrary.Data;
using GameLibrary.Domain.Model;
using GameLibrary.Domain.Repository;

namespace GameLibrary.Application.Repository
{
    public class GameRepository : Repository<Game, GameId>, IGameRepository
    {
        public GameRepository(Context context) : base(context) { }
    }
}