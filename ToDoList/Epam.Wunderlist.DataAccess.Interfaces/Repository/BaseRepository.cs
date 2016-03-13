using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Epam.Wunderlist.DataAccess.Interfaces.Mapper;
using System;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public abstract class BaseRepository<TDal, TOrm> : IRepository<TDal>
        where TDal : class, DTO.IEntity
        where TOrm : class, Orm.IEntity
    {
        protected readonly DbContext context;
        protected IMapper mapper= (IMapper)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IMapper));

        protected BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public virtual TDal GetById(int key)
        {
            TOrm model = context.Set<TOrm>().FirstOrDefault(e => e.Id == key);
            return mapper.Map<TOrm, TDal>(model);
        }

        public virtual int Create(TDal entity)
        {
            DbEntityEntry<TOrm> dbEntity=null;
            try {
                dbEntity = context.Entry<TOrm>( mapper.Map<TDal, TOrm>(entity));
                context.Set<TOrm>().Add(dbEntity.Entity);
                context.SaveChanges();
            }catch(Exception e)
            {

            }
            return dbEntity.Entity.Id;
            //if (entity == null)
            //    throw new ArgumentNullException(nameof(entity));
            //context.Set<TOrm>().Add(mapper.Map<TDal,TOrm>(entity));

        }

        public virtual bool Delete(int key)
        {
            //TOrm modelEntity = mapper.Map<TDal, TOrm>(entity);
            DbEntityEntry<TOrm> dbEntity = context.Entry<TOrm>(context.Set<TOrm>().Find(key));
            context.Set<TOrm>().Remove(dbEntity.Entity);
            return true;
        }

        public virtual bool Update(TDal entity)
        {
            TOrm modelEntity = mapper.Map<TDal, TOrm>(entity);
            var x = context.Set<TOrm>().Find(modelEntity.Id);
            if (x == null)
                return false;
            context.Entry(x).CurrentValues.SetValues(modelEntity);
            return true;
        }

    }
}
