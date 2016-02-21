using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Folder")]
    public partial class Folder
    {
        public Folder()
        {
            ToDoLists = new List<ToDoList>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AuthorId { get; set; }

        [Required]
        public int OrderIndex { get; set; }

        public virtual ICollection<ToDoList> ToDoLists { get; set; }
        public virtual User Author { get; set; }
    }
}
