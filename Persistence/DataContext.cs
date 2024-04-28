
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new Category[] {
                new Category { Id = 1, Name = "Science Fiction" },
                new Category { Id = 2, Name = "Fantasy" } 
            };

            var books = new Book[] {
                new Book {
                    Id = 1,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Author = "Douglas Adams",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0345391803",
                    CategoryId = 1,
                    ImgUrl = "https://en.wikipedia.org/wiki/The_Hitchhiker%27s_Guide_to_the_Galaxy_%28fictional%29",
                    Category = categories.FirstOrDefault(c => c.Id == 1)!
                },
                new Book {
                    Id = 2,
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0618219731",
                    CategoryId = 2,
                    ImgUrl = "https://en.wikipedia.org/wiki/Category:J._R._R._Tolkien_book_cover_images",
                    Category = categories.FirstOrDefault(c => c.Id == 2)!
                }
            };

            modelBuilder.Entity<Category>()
                .HasData(categories);

            modelBuilder.Entity<Book>()
                .HasData(books);
        }
    }
}
