using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class ItemModel
    {
        public DateTime CreationDateTime { get; set; }
        public DateTime RemindDateTime { get; set; }
        public DateTime CompletionDateTime { get; set; }
        public int RepeatKindId { get; set; }
        public int Intrerval { get; set; }
        public string Name { get; set; }
        public bool IsStarred { get; set; }
        public int OrderIndex { get; set; }
        public string Description { get; set; }
        public bool IsComleted { get; set; }
    }
}