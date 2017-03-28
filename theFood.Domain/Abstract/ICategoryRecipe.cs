using System.Linq;
using theFood.Domain.DbModel;

namespace theFood.Domain.Abstract
{
    public interface ICategoryRecipe
    {
        IQueryable<CategoryRecipe> CategoryRecipes { get; } 
    }
}
