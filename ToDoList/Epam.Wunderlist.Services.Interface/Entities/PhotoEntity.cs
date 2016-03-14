using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Services.Interface.Entities
{
    public class PhotoEntity : IEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}
