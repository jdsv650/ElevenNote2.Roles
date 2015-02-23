namespace DataAccess.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.ElevenNoteDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.ElevenNoteDataContext context)
        {
            IdentityDbContext identityContext = new IdentityDbContext();
            identityContext.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Admin" }
                                                         , new IdentityRole() { Name = "Lead" });
            identityContext.SaveChanges();

           


            context.Notes.AddOrUpdate(n => n.Title, new Note() { Title="T1", Contents="bacon ipsum", DateCreated=DateTime.Now, DateModified = DateTime.Now, NoteId=1},
                                              new Note() { Title="T2", Contents="Banana ipsum", DateCreated=DateTime.Now, DateModified = DateTime.Now, NoteId=2},
                                              new Note() { Title="T3", Contents="Lorem ipsum", DateCreated=DateTime.Now, DateModified = DateTime.Now, NoteId=3} );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
