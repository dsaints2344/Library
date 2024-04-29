using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly DataContext _dataContext;

        public InventoryService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<int> UpsertInventory(int bookId, int newAmount)
        {
            var bookToUpdate = await _dataContext.Books.Where(b => b.Id == bookId)
                .FirstOrDefaultAsync();

            if (bookToUpdate == null)
            {
                throw new Exception($"Book with id: {bookId} does not exists, please add the book before updating inventory");
            }

            var newInventoryLog = new Inventory
            {
                AvailableCopies = newAmount,
                Book = bookToUpdate,
                BookId = bookId
            };

            var inventoryExists = await _dataContext.Inventory.Where(i => i.BookId == bookId)
                .FirstOrDefaultAsync();

            if (inventoryExists != null)
            {
                inventoryExists.AvailableCopies = newAmount;
                _dataContext.Update(inventoryExists);
                await _dataContext.SaveChangesAsync();
            }

            await _dataContext.Inventory.AddAsync(newInventoryLog);

            return await _dataContext.SaveChangesAsync();
        }
    }
}
