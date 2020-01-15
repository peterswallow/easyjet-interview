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
    public class GetTests
    {
        private const string UnknownId = "1";
        private const string KnownId = "2";
        private List<IStoreable<string>> items;

        public GetTests()
        {
            items = new List<IStoreable<string>>
            {
                new Storeable<string>{ Id=KnownId }
            };
        }

        [Fact]
        public void Get_WhenIdIsNull_ThrowsExecption()
        {
            var repository = new Repository<IStoreable<string>, string>();

            Assert.Throws<NullReferenceException>(() => { repository.Get(null); });
        }

        [Fact]
        public void Get_GivenIdHasNoItem_ReturnsNull()
        {
            var repository = new Repository<IStoreable<string>, string>(items);

            var result = repository.Get(UnknownId);

            Assert.Null(result);
        }

        [Fact]
        public void Get_GivenIdIsIntAndHasItem_ReturnsItemIsNotNull()
        {
            var repository = new Repository<IStoreable<int>, int>(
                new List<IStoreable<int>> { new Storeable<int> { Id = 2 } }
            );

            var result = repository.Get(2);

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_GivenIdIsIntAndHasItem_ReturnsItemWithId()
        {
            var repository = new Repository<IStoreable<int>, int>(
               new List<IStoreable<int>> { new Storeable<int> { Id = 2 } }
           );

            var result = repository.Get(2);

            Assert.Equal(2, result.Id);
        }

        [Fact]
        public void Get_GivenIdIsStringHasItem_ReturnsItemIsNotNull()
        {
            var repository = new Repository<IStoreable<string>, string>(items);

            var result = repository.Get("2");

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_GivenIdIsStringAndHasItem_ReturnsItemWithId()
        {
            var repository = new Repository<IStoreable<string>, string>(items);

            var result = repository.Get("2");

            Assert.Equal(KnownId, result.Id);
        }
    }
}
