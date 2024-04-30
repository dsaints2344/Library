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
                new Category { Id = 2, Name = "Fantasy" },
                new Category { Id = 3, Name = "Mystery" },
                new Category { Id = 4, Name = "Historical Fiction" },
                new Category { Id = 5, Name = "Classics" },
};

            await context.Categories.AddRangeAsync(categories);

            var books = new Book[] {
                  new Book {
                    Id = 1,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Author = "Douglas Adams",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0345391803",
                    CategoryId = 1, // Science Fiction
                    ImgUrl = "https://en.wikipedia.org/wiki/The_Hitchhiker%27s_Guide_to_the_Galaxy_%28fictional%29"
                  },
                  new Book {
                    Id = 2,
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0618219731",
                    CategoryId = 2, // Fantasy
                    ImgUrl = "https://en.wikipedia.org/wiki/Category:J._R._R._Tolkien_book_cover_images"
                  },
 
                  new Book {
                    Id = 3,
                    Title = "And Then There Were None",
                    Author = "Agatha Christie",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0007146779",
                    CategoryId = 3, // Mystery
                    ImgUrl = "https://en.wikipedia.org/wiki/And_Then_There_Were_None"
                  },
                  new Book {
                    Id = 4,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0140439516",
                    CategoryId = 5, // Classics
                    ImgUrl = "https://en.wikipedia.org/wiki/Pride_and_Prejudice"
                  },
                  new Book {
                    Id = 5,
                    Title = "A Tale of Two Cities",
                    Author = "Charles Dickens",
                    PublishedDate = DateTime.UtcNow,
                    ISBN = "978-0140435000",
                    CategoryId = 4, // Historical Fiction
                    ImgUrl = "https://en.wikipedia.org/wiki/A_Tale_of_Two_Cities"
                  }
            };

            await context.Books.AddRangeAsync(books);

            var inventory = new Inventory[] {
                 new Inventory { BookId = 1, AvailableCopies = 5 },  
                 new Inventory { BookId = 2, AvailableCopies = 3 },
                 new Inventory { BookId = 3, AvailableCopies = 10 },
                 new Inventory { BookId = 4, AvailableCopies = 2 },
                 new Inventory { BookId = 5, AvailableCopies = 8 },
            };

            await context.Inventory.AddRangeAsync(inventory);
            await context.SaveChangesAsync();
        }
    }
}
