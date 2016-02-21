using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalItem: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ToDoListId { get; set; }
        public System.DateTime CreationDateTime { get; set; }
        public System.DateTime RemindDateTime { get; set; }
        public System.DateTime CompletionDateTime { get; set; }
        public int RepeatKindId { get; set; }
        public int Interval { get; set; }
        public bool IsStarred { get; set; }
        public int OrderIndex { get; set; }
        public int ExecutorId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }










    }
}
