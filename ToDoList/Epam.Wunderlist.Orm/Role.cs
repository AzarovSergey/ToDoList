using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.Orm
{
    [Table("Role")]
    public partial class Role : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string Name { get; set; }
    }
}
