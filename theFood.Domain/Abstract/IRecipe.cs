using System.Linq;
using theFood.Domain.DbModel;

namespace theFood.Domain.Abstract
{
    public interface IRecipe
    {
        IQueryable<Recipe> Recipes { get;}
        void SaveRecipe(Recipe recipe);
        Recipe DeleteRecipe(int productId);

    }
}
