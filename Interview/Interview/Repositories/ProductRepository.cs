using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Repositories
{
    public class ProductRepository : Repository<Product, int>
    {
        public ProductRepository(IEnumerable<Product> products) : base(products) { }        
    }
}
