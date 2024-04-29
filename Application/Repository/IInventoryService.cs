namespace Application.Repository
{
    public interface IInventoryService
    {
        Task<int> UpdateInventory(int bookId, int newAmount);
    }
}
