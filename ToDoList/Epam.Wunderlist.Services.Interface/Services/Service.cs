using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Interface.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.Services.Interface.Mappers;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public class Service<TEntity,TRepository,TRepositoryEntity>: IService<TEntity> 
        where TEntity : IEntity
        where TRepository : IRepository<TRepositoryEntity>
        where TRepositoryEntity : Epam.Wunderlist.DataAccess.Interfaces.DTO.IEntity
    {
        protected TRepository repository;
        protected IUnitOfWork uow;
        protected IMapper mapper;

        public Service(TRepository repository, IUnitOfWork uow, IMapper mapper)
        {
            this.repository = repository;
            this.uow = uow;
            this.mapper = mapper;
        }
        //public Service(TRepository repository)
        //{
        //    this.repository = repository;
        //}

        public int Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var newEntityId = repository.Create(mapper.Map<TEntity, TRepositoryEntity>(entity));
            uow.Commit();
            return newEntityId;
        }

        public TEntity GetById(int Id)
        {
            return mapper.Map<TRepositoryEntity,TEntity>(repository.GetById(Id));
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            bool result = repository.Update(mapper.Map<TEntity,TRepositoryEntity>(entity));
            uow.Commit();
            return result;

        }

        public bool Delete(int id)
        {
            var result = repository.Delete(id);
            uow.Commit();
            return result;
        }
    }
}
