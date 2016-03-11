namespace Epam.Wunderlist.DataAccess.Interfaces.DTO
{
    public class DalFolder : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int OrderIndex { get; set; }

    }
}
