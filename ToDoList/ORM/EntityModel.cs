using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
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
        public DbSet<RepeatKind> RepeatKinds { get; set; }
        public DbSet<ToDoListFolder> ToDoListsFolders { get; set; }


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
                    new Folder() { Name = "Folder 1", Author = u1, OrderIndex = 4 },
                    new Folder() { Name = "Folder 2", Author = u1, OrderIndex = 3 },
                    new Folder() { Name = "Folder 3", Author = u1, OrderIndex = 2 },
                    new Folder() { Name = "Folder 4", Author = u1, OrderIndex = 1 },
                    new Folder() { Name = "Folder u3", Author = u3, OrderIndex = 2 },
                };
                //ToDoList list1 = new ToDoList() { Name = "List 1" };
                //ToDoList list2 = new ToDoList() { Name = "List 2" };
                //ToDoListFolder lf1 = new ToDoListFolder() { ToDoListId = list1.Id, FolderId = folder1.Id, IndexInFolder = 1 };
                //ToDoListFolder lf2 = new ToDoListFolder() { ToDoListId = list2.Id, FolderId = folder2.Id, IndexInFolder = 2 };
                //Item i1 = new Item() { Name = "Item 1", ToDoListId = list1.Id, ExecutorId = u1.Id, OrderIndex = 1 };
                //Item i2 = new Item() { Name = "Item 2", ToDoListId = list2.Id, ExecutorId = u2.Id, OrderIndex = 2 };
               
                context.Roles.Add(roleUser);
                context.Roles.Add(roleAdmin);
                context.Users.Add(u1);
                context.Users.Add(u2);
                context.Users.Add(u3);
               // context.RepeatKinds.Add(kind1);
                foreach(Folder folder in folders)
                {
                    context.Folders.Add(folder);
                }
                //context.ToDoLists.Add(list1);
                //context.ToDoLists.Add(list2);
                //context.Items.Add(i1);
                //context.Items.Add(i2);
                //context.ToDoListsFolders.Add(lf1);
                //context.ToDoListsFolders.Add(lf2);

            }
        }


    }
}