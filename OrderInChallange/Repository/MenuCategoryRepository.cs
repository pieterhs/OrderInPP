using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class MenuCategoryRepository : RepositoryBase<MenuCategory>, IMenuCategoryRepository
    {
        public MenuCategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
