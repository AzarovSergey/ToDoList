using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Item")]
    public partial class Item
    {
        public Item()
        {

        }

        [Key]
        public int Id { get; set;}

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        //[ForeignKey("ToDoList")]
        public int ToDoListId { get; set;}

        [Required]
        public System.DateTime CreationDateTime { get; set; }

        [Required]
        public System.DateTime RemindDateTime { get; set; }

        [Required]
        public System.DateTime СompletionDateTime { get; set; }

        [Required]
       // [ForeignKey("RepeatKind")]
        public int RepeatKindId { get; set;}

        [Required]
        public int Interval { get; set;}

        [Required]
        public bool IsStarred { get; set;}

        [Required]
        public int OrderIndex { get; set;}

        [Required]
       // [ForeignKey("User")]
        public int ExecutorId { get; set;}

        [Required]
        [StringLength(500)]
        public string Description { get; set;}

        [Required]
        public bool IsCompleted { get; set;}

        public virtual ToDoList Container { get; set; }
    }
}
