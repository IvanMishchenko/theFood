using System;
using System.Data.Entity;
using System.Linq;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;

namespace theFood.Domain.Concrete
{
    public class IngridientRepository:IIngridient
    {
        private readonly Model_theFoodDbContainer _dbContext = new Model_theFoodDbContainer();
        public IQueryable<Ingridient> Ingridients
        {
            get { return _dbContext.IngridientSet; }
        }

        public void SaveIngridient(int recipeId, string[] checkedValues)
        {
            if (checkedValues != null)
            {
                foreach (var value in checkedValues)
                {
                    _dbContext.IngridientSet.Add(new Ingridient
                    {
                        RecipeId = recipeId,
                        ProductId = Convert.ToInt32(value)
                    });
                }
                _dbContext.SaveChanges();
            }
        }

        public Ingridient DeleteIngridient(int id)
        {
            throw new System.NotImplementedException();
        }

      

    }
}
