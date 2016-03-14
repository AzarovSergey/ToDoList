using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.Orm
{
    [Table("Photo")]
    public partial class Photo : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
