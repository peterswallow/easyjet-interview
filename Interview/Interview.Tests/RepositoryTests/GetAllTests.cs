using Interview.Entities;
using Interview.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Interview.Tests
{
    public class GetAllTests
    {
        private List<IStoreable<int>> items;

        public GetAllTests()
        {
            items = new List<IStoreable<int>>
            {
                new Storeable<int>(),
                new Storeable<int>()
            };
        }

        [Fact]
        public void GetAll_WhenRepositoryHasItems_ReturnsArrayWithItems()
        {
            var repository = new Repository<IStoreable<int>, int>(items);

            var result = repository.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAll_WhenRepositoryHasItems_ReturnsArrayWithItemsOfCorrectType()
        {
            var repository = new Repository<IStoreable<int>, int>(items);

            var result = repository.GetAll();

            Assert.IsType<Storeable<int>>(result.First());
        }
    }
}
