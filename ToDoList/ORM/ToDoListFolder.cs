using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("ToDoListFolder")]
    public partial class ToDoListFolder
    {
        public ToDoListFolder()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
       // [ForeignKey("ToDoList")]
        public int ToDoListId { get; set; }

        [Required]
        //[ForeignKey("Folder")]
        public int FolderId { get; set; }

        [Required]
        public int IndexInFolder { get; set;}
    }
}
