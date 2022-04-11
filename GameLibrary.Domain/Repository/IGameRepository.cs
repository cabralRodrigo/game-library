using GameLibrary.Domain.Model;

namespace GameLibrary.Domain.Repository
{
    public interface IGameRepository : IRepository<Game, GameId> { }
}