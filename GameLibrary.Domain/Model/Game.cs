namespace GameLibrary.Domain.Model
{
    public class Game : IModel<GameId>
    {
        public GameId Id { get; set; }
        public string Name { get; set; } = default!;
    }

    [StronglyTypedId]
    public partial struct GameId { }
}