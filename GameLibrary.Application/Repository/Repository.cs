using GameLibrary.Data;
using GameLibrary.Domain.Model;
using GameLibrary.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Application.Repository
{
    public abstract class Repository<TModel, TId> : IRepository<TModel, TId>
        where TModel : class, IModel<TId>, new()
    {
        protected Context Context { get; }

        public Repository(Context context) => this.Context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<TModel?> Find(TId id) => await this.Context.Set<TModel>().FindAsync(id);

        public async Task<int> Delete(TId id)
        {
            this.Context.Remove(new TModel { Id = id });
            return await this.Context.SaveChangesAsync();
        }

        public async Task<TId> Insert(TModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            this.Context.Add(model);
            await this.Context.SaveChangesAsync();

            return model.Id;
        }

        public async Task<TModel[]> List()
        {
            return await this.Context.Set<TModel>().ToArrayAsync();
        }

        public async Task<TModel[]> List(IEnumerable<TId>? ids) => await this.MultipleIds(ids, this.Find, ids => this.Context.Set<TModel>().Where(s => ids.Contains(s.Id)).ToArrayAsync());

        public async Task<int> Update(TModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            this.Context.Entry(model).State = EntityState.Modified;
            this.Context.Update(model);

            return await this.Context.SaveChangesAsync();
        }

        protected async Task<TModel[]> MultipleIds(IEnumerable<TId>? ids, Func<TId, Task<TModel?>> a, Func<TId[], Task<TModel[]>> b) => ids switch
        {
            null => Array.Empty<TModel>(),
            _ => ids.ToArray() switch
            {
                { Length: 0 } => Array.Empty<TModel>(),
                var x when x is { Length: 1 } => await a(x[0]) switch
                {
                    TModel model => new[] { model },
                    _ => Array.Empty<TModel>(),
                },
                var x => await b(x)
            },
        };
    }
}