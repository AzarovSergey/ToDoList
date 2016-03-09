﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Interfaces.DTO;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int key);
        int Create(TEntity e);
        void Delete(TEntity e);
        void Update(TEntity entity);
    }
}