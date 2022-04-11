namespace GameLibrary.Domain.Model
{
    public interface IModel<TId>
    {
        TId Id { get; set; }
    }
}