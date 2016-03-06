using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Services.Interface.Entities
{
    public class ItemEntity : IEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ToDoListId { get; set; }
        public DateTime DueDateTime { get; set; }
        public bool IsStarred { get; set; }
        public int OrderIndex { get; set; }
        public string Note { get; set; }
        public bool IsComleted { get; set; }
    }
}
