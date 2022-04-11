using GameLibrary.Domain.Model;
using GameLibrary.Domain.Repository;
using GameLibrary.Domain.Service;

namespace GameLibrary.Application.Service
{
    public class GameService : Service<Game, GameId, IGameRepository>, IGameService
    {
        public GameService(IGameRepository repository) : base(repository) { }
    }
}