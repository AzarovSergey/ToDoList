﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.Orm
{
    [Table("User")]
    public partial class User : IEntity
    {
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
        public int RoleId { get; set; }

        //[Required]
        public int PhotoId { get; set; }

        public virtual Role Role { get; set; }
    }
}
