using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Epam.Wunderlist.Orm
{
    [Table("User")]
    public partial class User
    {

        public User()
        {
            //Articles = new List<Article>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        public bool IsEmailNotification { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        //[ForeignKey("Theme")]
        public int ThemeId { get; set; }
        
        
        public byte[] Photo { get; set; }

        public virtual Role Role { get; set; }
       // public virtual ICollection<A> A { get; set; }
       // public virtual Theme Theme { get; set; }
    }
}
