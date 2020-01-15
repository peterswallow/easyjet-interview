using Interview.Repositories;
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
        public void GetAll_WhenRepositoryHasItems_ReturnsArrayWithItems()
        {
            var repository = new ProductRepository(products);

            var result = repository.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAll_WhenRepositoryHasItems_ReturnsArrayWithItemsOfCorrectType()
        {
            var repository = new ProductRepository(products);

            var result = repository.GetAll();

            Assert.IsType<Product>(result.First());
        }
    }
}
