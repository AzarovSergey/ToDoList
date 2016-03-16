using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Services.Interface.Services
{
    public interface IService<T>
    {
        int Create(T entity);
        T GetById(int Id);
        bool Update(T entity);
        bool Delete(int id);
    }
}
