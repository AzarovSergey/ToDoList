namespace Epam.Wunderlist.DataAccess.Interfaces.DTO
{
    public class DalToDoList : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FolderId { get; set; }
    }
}
