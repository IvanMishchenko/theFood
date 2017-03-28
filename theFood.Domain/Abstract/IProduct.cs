using System.Linq;
using theFood.Domain.DbModel;

namespace theFood.Domain.Abstract
{
    public interface IProduct
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
