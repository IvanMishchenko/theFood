using System.Linq;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;

namespace theFood.Domain.Concrete
{
    public class CategoryRecipeRepository:ICategoryRecipe
    {
       readonly Model_theFoodDbContainer _dbContext = new Model_theFoodDbContainer();
       public IQueryable<CategoryRecipe> CategoryRecipes
        {
            get { return _dbContext.CategoryRecipeSet; }
        }
    }
}
