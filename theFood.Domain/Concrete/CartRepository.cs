using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;

namespace theFood.Domain.Concrete
{
    public class Cart:ICart
    {
        private readonly List<CartLine> _cartCollections = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            var line = _cartCollections.FirstOrDefault(x => x.Product.Id == product.Id);
            if (line==null)
            {
                _cartCollections.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
          _cartCollections.RemoveAll(x => x.Product.Id == product.Id);
        }

        public void Clear()
        {
            _cartCollections.Clear();
        }

        public IEnumerable<CartLine> Lines { get { return _cartCollections; } } 
    }

    public class CartLine
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
