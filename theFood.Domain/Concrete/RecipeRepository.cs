using System.Linq;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;

namespace theFood.Domain.Concrete
{
    public class RecipeRepository:IRecipe
    {
        private readonly Model_theFoodDbContainer _dbContext = new Model_theFoodDbContainer ();
        public IQueryable<Recipe> Recipes
        {
            get { return _dbContext.RecipeSet; }
        }
        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.Id == 0)
            {
                _dbContext.RecipeSet.Add(recipe);
            }
            else
            {
                var dbEntry = _dbContext.RecipeSet.Find(recipe.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = recipe.Name;
                    dbEntry.CookingTime = recipe.CookingTime;
                    dbEntry.Text = recipe.Text;
                    dbEntry.EatingTimeId = recipe.EatingTimeId;
                    dbEntry.LikeDislike = recipe.LikeDislike;
                    dbEntry.Price = recipe.Price;
                    dbEntry.RatingRecipe = recipe.RatingRecipe;
                    dbEntry.CategoryRecipeId = recipe.CategoryRecipeId;
                    dbEntry.UniqueName = recipe.UniqueName;

                }
            }
            _dbContext.SaveChanges();
        }

        public Recipe DeleteRecipe(int productId)
        {
            var dbEntry = _dbContext.RecipeSet.Find(productId);
            if (dbEntry != null)
            {
                _dbContext.RecipeSet.Remove(dbEntry);
               
                _dbContext.SaveChanges();
            }
            return dbEntry;
        }

    }
}
