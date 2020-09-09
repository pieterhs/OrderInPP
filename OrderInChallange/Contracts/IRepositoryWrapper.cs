namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IMenuItemRepository MenuItem { get; }
        IMenuCategoryRepository MenuCategory { get; }
        IRestaurantRepository Restaurant { get; }
        void Save();

    }
}
