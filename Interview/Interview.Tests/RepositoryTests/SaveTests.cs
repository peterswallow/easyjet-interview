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
    public class SaveTests
    {
        [Fact]
        public void Save_GivenItemIsNull_ThrowsExecption()
        {
            var repository = new Repository<IStoreable<string>, string>();

            Assert.Throws<NullReferenceException>(() => { repository.Save(null); });
        }

        [Fact]

        public void Save_GivenNewItem_ShouldAddAnItemToList()
        {
            var repository = new Repository<IStoreable<string>, string>();

            repository.Save(new Storeable<string> { Id = "1" });

            Assert.Single(repository.GetAll());
        }

        [Fact]
        public void Save_GivenNewItem_ShouldAddAnItemToListWithId()
        {
            var repository = new Repository<IStoreable<string>, string>();

            repository.Save(new Storeable<string> { Id = "1" });

            Assert.Equal("1", repository.GetAll().Single().Id);
        }

        [Fact]
        public void Save_GivenItemWithIdThatAlreadyExists_ShouldThrowException()
        {
            var repository = new Repository<IStoreable<string>, string>(
                new List<IStoreable<string>> {
                    new Storeable<string> { Id = "2" }
                });

            Assert.Throws<InvalidOperationException>(() => {
                repository.Save(new Storeable<string> { Id = "2" });
            });
        }
    }
}
