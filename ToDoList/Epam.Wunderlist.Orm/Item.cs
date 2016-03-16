using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.Orm
{
    [Table("Item")]
    public partial class Item : IEntity
    {
        [Key]
        public int Id { get; set;}

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int ToDoListId { get; set;}

        [Required]
        public DateTime DueDateTime { get; set; }

        [Required]
        public bool IsStarred { get; set;}

        [Required]
        public int OrderIndex { get; set;}

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public string Note { get; set;}

        [Required]
        public bool IsCompleted { get; set;}

        public virtual ToDoList ToDoList { get; set; }
    }
}
