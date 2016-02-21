using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class ToDoListModel
    {
        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public IEnumerable<ItemModel> Items { get; set; }
    }
}