using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummyBearKingdom.Models.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Product Save(Product Product);
        Product Edit(Product Product);
        void Remove(Product Product);
    }
}
