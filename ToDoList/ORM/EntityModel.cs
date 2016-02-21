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
                context.Roles.Add(roleUser);
                context.Roles.Add(roleAdmin);
                context.Users.Add(u1);
                context.Users.Add(u2);
                context.Users.Add(u3);
            }
        }


    }
}