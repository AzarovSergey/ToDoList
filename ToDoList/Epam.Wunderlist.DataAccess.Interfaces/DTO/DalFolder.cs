using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.DataAccess.Interfaces.DTO
{
    public class DalFolder : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int OrderIndex { get; set; }

    }
}
