namespace Epam.Wunderlist.Services.Interface.Entities
{
    public class FolderEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
