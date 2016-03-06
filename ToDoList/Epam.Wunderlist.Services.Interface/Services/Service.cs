using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public class Service<TEntity,TRepository>: IService<TEntity> 
        where TEntity :IEntity, TRepository :IRepository<Epam.Wunderlist.DataAccess.Interfaces.DTO.IEntity>
    {
        protected TRepository repository;
        protected IUnitOfWork uow;

        public Service(TRepository repository, IUnitOfWork uow)
        {
            this.repository = repository;
            this.uow = uow;
        }

        public int Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return repository.Create(entity.ToDal());
        }

        public TEntity GetById(int Id)
        {
            return repository.GetById(Id).ToBll();
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            bool result = repository.Update(entity.ToDal());
            uow.Commit();
            return result;

        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
