using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Interview.Tests
{
    public class RepositoryTests
    {
        private List<Product> products;

        public RepositoryTests()
        {
            products = new List<Product>
            {
                new Product(),
                new Product()
            };
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsArrayWithItems()
        {
            var repository = new Repository<Product, int>(products);

            var result = repository.GetAll();

            Assert.Equal(2, result.Count());
        }
    }
}
