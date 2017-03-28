using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFood.Domain.Concrete;
using theFood.Domain.DbModel;

namespace theFood.Domain.Abstract
{
    public interface ICart
    {
        void AddItem(Product product, int quantity);
        void RemoveLine(Product product);
        void Clear();
        IEnumerable<CartLine> Lines { get; }
    }
}
