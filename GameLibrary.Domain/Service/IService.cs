using GameLibrary.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLibrary.Domain.Service
{
    public interface IService<TModel, TId>
        where TModel : IModel<TId>
    {
        Task<TModel?> Find(TId id);
        Task<TModel[]> List();
        Task<TModel[]> List(IEnumerable<TId> ids);

        Task<int> Update(TModel model);
        Task<TId> Insert(TModel model);
        Task<int> Delete(TId id);
    }
}