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
    public class DeleteTests
    {
        [Fact]
        public void Delete_GivenItemIsNull_ThrowsExecption()
        {
            var repository = new Repository<IStoreable<string>, string>();

            Assert.Throws<NullReferenceException>(() => { repository.Delete(null); });
        }

        [Fact]
        public void Delete_GivenItemWithIdThatDoesNotExist_ShouldThrowException()
        {
            var repository = new Repository<IStoreable<string>, string>(
                new List<IStoreable<string>> {
                    new Storeable<string> { Id = "1" }
                });

            Assert.Throws<InvalidOperationException>(() => {
                repository.Delete("2");
            });
        }

        [Fact]
        public void Delete_GivenItemWithIdThatDoesExist_ShouldRemoveAnItem()
        {
            var repository = new Repository<IStoreable<string>, string>(
                new List<IStoreable<string>> {
                    new Storeable<string> { Id = "1" },
                    new Storeable<string> { Id = "2" }
                });

            repository.Delete("1");

            Assert.Single(repository.GetAll());
        }

        [Fact]
        public void Delete_GivenItemWithIdThatDoesExist_ShouldRemoveTheItemWithId()
        {
            var idToRemove = "1";
            var repository = new Repository<IStoreable<string>, string>(
                new List<IStoreable<string>> {
                    new Storeable<string> { Id = idToRemove },
                    new Storeable<string> { Id = "2" }
                });

            repository.Delete(idToRemove);

            Assert.False(repository.GetAll().Any(item => item.Id == idToRemove));
        }
    }
}
