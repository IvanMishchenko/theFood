using System.Linq;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;

namespace theFood.Domain.Concrete
{
    public class ProductRepository:IProduct
    {
        readonly Model_theFoodDbContainer _dbContext = new Model_theFoodDbContainer();
        public IQueryable<Product> Products
        {
            get { return _dbContext.ProductSet; }
        }

        public void SaveProduct(Product product)
        {
            if (product.Id==0)
            {
                _dbContext.ProductSet.Add(product);
            }
            else
            {
                var dbEntry = _dbContext.ProductSet.Find(product.Id);
                if (dbEntry!=null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.PriceOnProduct = product.PriceOnProduct;
                    dbEntry.Description = product.Description;
                    dbEntry.CategoryProductId = product.CategoryProductId;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageName = product.ImageName;
                }
            }
            _dbContext.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var dbEntry = _dbContext.ProductSet.Find(productId);
            if (dbEntry!=null)
            {
                _dbContext.ProductSet.Remove(dbEntry);
                var ingridientEntry = _dbContext.IngridientSet.FirstOrDefault(x => x.ProductId == productId);
                if (ingridientEntry!=null)
                {
                   _dbContext.IngridientSet.Remove(ingridientEntry);
                }
                _dbContext.SaveChanges();
            }
            return dbEntry;
        }
      
    }
}
