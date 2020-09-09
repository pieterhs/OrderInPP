using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IMenuItemRepository _menuItem;
        private IMenuCategoryRepository _menuCategory;
        private IRestaurantRepository _restaurant;

        public IMenuItemRepository MenuItem
        {
            get
            {
                if (_menuItem == null)
                {
                    _menuItem = new MenuItemRepository(_repositoryContext);
                }
                return _menuItem;
            }
        }

        public IMenuCategoryRepository MenuCategory
        {
            get
            {
                if (_menuCategory == null)
                {
                    _menuCategory = new MenuCategoryRepository(_repositoryContext);
                }
                return _menuCategory;
            }
        }

        public IRestaurantRepository Restaurant
        {
            get
            {
                if (_restaurant == null)
                {
                    _restaurant = new RestaurantRepository(_repositoryContext);
                }
                return _restaurant;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

    }
}
