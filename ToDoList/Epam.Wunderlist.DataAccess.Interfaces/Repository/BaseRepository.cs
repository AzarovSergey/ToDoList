using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Epam.Wunderlist.Orm;
using Epam.Wunderlist.DataAccess.Interfaces.Mapper;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class BaseRepository<TDal, TOrm> : IRepository<TDal>
        where TDal : class, DTO.IEntity
        where TOrm : class, Orm.IEntity
    {
        private readonly DbContext context;
        protected IMapper<TOrm, TDal> mapper = new TMapper();

        protected BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<TDal> GetAll()
        {
            return context.Set<TOrm>().Select(mapper.ToDal);
        }

        public virtual TDal GetById(int key)
        {
            TOrm model = context.Set<TOrm>().FirstOrDefault(e => e.Id == key);
            return mapper.ToDal(model);
        }

        public virtual int Create(TDal entity)
        {
            TOrm modelEntity = mapper.ToOrm(entity);
            DbEntityEntry<TOrm> dbEntity = context.Entry<TOrm>(modelEntity);
            context.Set<TOrm>().Add(dbEntity.Entity);
            context.SaveChanges();
            return dbEntity.Entity.Id;
        }

        public virtual void Delete(TDal entity)
        {
            TOrm modelEntity = mapper.ToOrm(entity);
            DbEntityEntry<TOrm> dbEntity = context.Entry<TOrm>(context.Set<TOrm>().Find(entity.Id));
            context.Set<TOrm>().Remove(dbEntity.Entity);
        }

        public virtual void Update(TDal entity)
        {
            TOrm modelEntity = mapper.ToOrm(entity);
            var x = context.Set<TOrm>().Find(modelEntity.Id);
            context.Entry(x).CurrentValues.SetValues(modelEntity);
        }

    }
}
