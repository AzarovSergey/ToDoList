using System.Drawing;

namespace Epam.Wunderlist.DataAccess.Interfaces.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int PhotoId { get; set; }
    }
}
