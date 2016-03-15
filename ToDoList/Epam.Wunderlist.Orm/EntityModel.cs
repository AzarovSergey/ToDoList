using System;
using System.Data.Entity;

namespace Epam.Wunderlist.Orm
{
    public partial class EntityModel : DbContext
    {


        public EntityModel()
                : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateInitializer());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Photo> Photos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        private class OnceInitializer : CreateDatabaseIfNotExists<EntityModel>
        {
            protected override void Seed(EntityModel context)
            {
                base.Seed(context);
            }
        }

        private class DropCreateInitializer : DropCreateDatabaseAlways<EntityModel>
        {
            protected override void Seed(EntityModel context)
            {
                base.Seed(context);

                Role roleUser = new Role() { Name = "User" };
                Role roleAdmin = new Role() { Name = "Admin" };
                User u1 = new User() { Name = "User 1", Role = roleUser, Password = "p1", Email = "u1@m.c" };
                User u2 = new User() { Name = "User 2", Role = roleUser, Password = "p2", Email = "u2@m.c" };
                User u3 = new User() { Name = "User 3", Role = roleUser, Password = "p3", Email = "u3@m.c" };
                

                //RepeatKind kind1 = new RepeatKind() { Name = "Kind 1" };
                Folder[] folders = new Folder[] {
                    new Folder() { Name = "Folder 1", User = u1 },
                    new Folder() { Name = "Folder 2", User = u1 },
                    new Folder() { Name = "Folder 3", User = u1 },
                    new Folder() { Name = "Folder 4", User = u1 },
                    new Folder() { Name = "Folder u3", User = u3 },
                };
                ToDoList[] toDoLists = new ToDoList[]
                {
                    new ToDoList() {Folder=folders[0],Name="the first list" },
                    new ToDoList() {Folder=folders[0],Name="L2" },
                    new ToDoList() {Folder=folders[2],Name="L3" },
                    new ToDoList() {Folder=folders[2],Name="L4" },
                    new ToDoList() {Folder=folders[0],Name="L5" },
                    new ToDoList() {Folder=folders[0],Name="L6" },
                };
                Item[] items = new Item[]
                {
                    new Item() {Name="item1",Note="note1",ToDoList=toDoLists[0],DueDateTime=DateTime.Now },
                    new Item() {Name="item2",Note="note2",ToDoList=toDoLists[0],DueDateTime=DateTime.Now },
                    new Item() {Name="item3",Note="note3",ToDoList=toDoLists[1],DueDateTime=DateTime.Now },
                    new Item() {Name="item4",Note="note4",ToDoList=toDoLists[1],DueDateTime=DateTime.Now },
                    new Item() {Name="item5",Note="note5",ToDoList=toDoLists[0],DueDateTime=DateTime.Now },
                    new Item() {Name="item6",Note="note6",ToDoList=toDoLists[2],DueDateTime=DateTime.Now },
                    new Item() {Name="item7",Note="note7",ToDoList=toDoLists[1],DueDateTime=DateTime.Now },
                    new Item() {Name="item8",Note="note8",ToDoList=toDoLists[2],DueDateTime=DateTime.Now },
                };
               
                context.Roles.Add(roleUser);
                context.Roles.Add(roleAdmin);
                context.Users.Add(u1);
                context.Users.Add(u2);
                context.Users.Add(u3);

                foreach(Folder folder in folders)
                {
                    context.Folders.Add(folder);
                }

                foreach(ToDoList toDoList in toDoLists)
                {
                    context.ToDoLists.Add(toDoList);
                }

                foreach(Item item in items)
                {
                    context.Items.Add(item);
                }
            }
        }


    }
}