using GameLibrary.Domain.Model;
using GameLibrary.Domain.Repository;
using GameLibrary.Domain.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLibrary.Application.Service
{
    public abstract class Service<TModel, TId, TRepository> : IService<TModel, TId>
        where TModel : IModel<TId>
        where TRepository : IRepository<TModel, TId>
    {
        protected TRepository Repository { get; }

        protected Service(TRepository repository) => this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<int> Delete(TId id) => await this.Repository.Delete(id);

        public async Task<TModel?> Find(TId id) => await this.Repository.Find(id);

        public async Task<TId> Insert(TModel model) => await this.Repository.Insert(model);

        public async Task<TModel[]> List() => await this.Repository.List();

        public async Task<TModel[]> List(IEnumerable<TId> ids) => await this.Repository.List(ids);

        public async Task<int> Update(TModel model) => await this.Repository.Update(model);
    }
}