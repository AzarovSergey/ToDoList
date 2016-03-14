using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.DataAccess.Interfaces.DTO
{
    public class DalPhoto : IEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}
