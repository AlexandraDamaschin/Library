namespace Library.Migrations.LibraryMigrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Models.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"LibraryMigrations";
        }

        protected override void Seed(Library.Models.LibraryContext context)
        {
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
            //seeding methods
            //SeedMembers(context);
            // SeedBooks(context);
           // SeedLoanBooks(context);
        }

        //seedMembers
        private void SeedMembers(LibraryContext context)
        {
            context.Members.AddOrUpdate(u => u.MemberId, new Member
            {
                FirstName = "John",
                SecondName = "Smith",
                DateJoined = DateTime.Now
            });

            context.Members.AddOrUpdate(u => u.MemberId, new Member
            {
                FirstName = "Jimmy",
                SecondName = "Johnson",
                DateJoined = DateTime.Now
            });
        }

        //seedBooks
        private void SeedBooks(LibraryContext context)
        {
            context.Books.AddOrUpdate(u => u.BookId, new Book
            {
                Author = "Phil Knight",
                ISBN = "123456",
                Title = "Shoe Dog"
            });

            context.Books.AddOrUpdate(u => u.BookId, new Book
            {
                Author = "James Smith",
                ISBN = "123432",
                Title = "Titanic"
            });

            context.Books.AddOrUpdate(u => u.BookId, new Book
            {
                Author = "Jack Bloggs",
                ISBN = "123333",
                Title = "Awesome Book"
            });
        }

        // loan book to one of the members
        private void SeedLoanBooks(LibraryContext context)
        {
            context.Loans.AddOrUpdate(p => p.LoanId,
                new Loan[] {
                    new Loan { MemberId=1,
                               BookId = 2, 
                               LoanDate = DateTime.Now  }
                                });
        }

    }
}
