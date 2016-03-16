namespace Epam.Wunderlist.Services.Interface.Entities
{
    public class ToDoListEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FolderId { get; set; }
    }
}
