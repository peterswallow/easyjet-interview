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
        private List<EntityWithStringId> items;

        public GetTests()
        {
            items = new List<EntityWithStringId>
            {
                new EntityWithStringId{ Id=KnownId }
            };
        }

        [Fact]
        public void Get_WhenIdIsNull_ThrowsExecption()
        {
            var repository = new Repository<EntityWithStringId, string>();

            Assert.Throws<NullReferenceException>(() => { repository.Get(null); });
        }

        [Fact]
        public void GetAll_GivenIdHasNoItem_ReturnsNull()
        {
            var repository = new Repository<EntityWithStringId, string>(items);

            var result = repository.Get(UnknownId);

            Assert.Null(result);
        }

        [Fact]
        public void GetAll_GivenIdHasItem_ReturnsItemIsNotNull()
        {
            var repository = new Repository<EntityWithStringId, string>(items);

            var result = repository.Get("2");

            Assert.NotNull(result);
        }

        [Fact]
        public void GetAll_GivenIdHasItem_ReturnsItemWithId()
        {
            var repository = new Repository<EntityWithStringId, string>(items);

            var result = repository.Get("2");

            Assert.Equal(KnownId, result.Id);
        }
    }
}
