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
            Database.SetInitializer(new OnceInitializer());
        }


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

        private class Initializer : DropCreateDatabaseAlways<EntityModel>
        {
            protected override void Seed(EntityModel context)
            {
                base.Seed(context);

            }
        }

    }
}