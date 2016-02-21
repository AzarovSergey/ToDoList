using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Repository
{
    public interface IItemRepository : IRepository<DalItem>
    {
        IEnumerable<DalItem> GetByToDoListId(int todolistid);
    }
}
