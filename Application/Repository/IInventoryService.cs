namespace Application.Repository
{
    public interface IInventoryService
    {
        Task<int> UpsertInventory(int bookId, int newAmount);
    }
}
