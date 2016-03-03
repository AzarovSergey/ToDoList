using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.Orm
{
    [Table("ToDoList")]
    public partial class ToDoList
    {
        public ToDoList()
        {
            Items = new List<Item>();
        }

        [Key]
        public int Id { get; set;}

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        //[ForeignKey("Folder")]
        public int FolderId { get; set; }


        public virtual ICollection<Item> Items { get; set; }
    }
}
