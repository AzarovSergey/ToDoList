using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public int ToDoListId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime RemindDateTime { get; set; }
        public DateTime CompletionDateTime { get; set; }
        public int RepeatKindId { get; set; }
        public int Intrerval { get; set; }
        public string Name { get; set; }
        public bool IsStarred { get; set; }
        public int OrderIndex { get; set; }
        public int ExecutorId { get; set; }
        public string Description { get; set; }
        public bool IsComleted { get; set; }
    }
}
