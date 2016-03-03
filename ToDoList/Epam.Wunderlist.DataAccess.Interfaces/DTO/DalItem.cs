using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.DataAccess.Interfaces.DTO
{
    public class DalItem: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ToDoListId { get; set; }
        public System.DateTime DueDateTime { get; set; }
        public bool IsStarred { get; set; }
        public int OrderIndex { get; set; }
        public int ExecutorId { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }










    }
}
