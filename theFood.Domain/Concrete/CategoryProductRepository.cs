using System.Linq;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;

namespace theFood.Domain.Concrete
{
   public class CategoryProductRepository:ICategoryProduct
    {
        private readonly Model_theFoodDbContainer _dbContext = new Model_theFoodDbContainer();
        
        public IQueryable<CategoryProduct> CategoryProducts
        {
            get { return _dbContext.CategoryProductSet; }
        }
    }
}
