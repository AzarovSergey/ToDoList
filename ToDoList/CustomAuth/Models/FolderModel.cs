using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class FolderModel
    {
        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public IEnumerable<ToDoListModel> ToDoLists { get; set; }
    }
}