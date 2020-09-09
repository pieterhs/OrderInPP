using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class MenuItemRepository : RepositoryBase<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
