using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Wunderlist.Web.Models
{
    public class FolderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ToDoListModel> ToDoLists { get; set; }
    }
}