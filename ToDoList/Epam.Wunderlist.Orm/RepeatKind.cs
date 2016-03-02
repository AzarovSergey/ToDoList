using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Epam.Wunderlist.Orm
{
    [Table("RepeatKind")]
    public partial class RepeatKind
    {
        public RepeatKind()
        {

        }

        [Key]
        public int Id { get; set;}

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
