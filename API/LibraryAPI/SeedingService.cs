using Domain;
using Persistence;

namespace LibraryAPI
{
    public class SeedingService
    {
        private readonly DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public static async Task SeedData(DataContext context)
        {
            var categories = new Category[] {
                new Category { Id = 1, Name = "Science Fiction" },
                new Category { Id = 2, Name = "Fantasy" }
            };

            await context.Categories.AddRangeAsync(categories);

            var books = new Book[] {
                new Book {
                    Id = 1,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Author = "Douglas Adams",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0345391803",
                    CategoryId = 1,
                    ImgUrl = "https://en.wikipedia.org/wiki/The_Hitchhiker%27s_Guide_to_the_Galaxy_%28fictional%29"
                },
                new Book {
                    Id = 2,
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0618219731",
                    CategoryId = 2,
                    ImgUrl = "https://en.wikipedia.org/wiki/Category:J._R._R._Tolkien_book_cover_images"
                }
            };

            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();
        }
    }
}
