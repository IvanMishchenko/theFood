using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFood.Domain.DbModel;

namespace theFood.Domain.Abstract
{
    public interface ICategoryProduct
    {
        IQueryable<CategoryProduct> CategoryProducts { get; } 
    }
}
