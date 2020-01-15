using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Repositories
{
    public class Repository<T, I> : IRepository<T, I>
        where T : IStoreable<I>
    {
        private IList<T> Items; 
        
        public Repository()
        {
            Items = new List<T>();
        }

        public Repository(IList<T> items)
        {
            this.Items = items;
        }

        public void Delete(I id)
        {
            throw new NotImplementedException();
        }

        public T Get(I id)
        {
            if (id == null)
                throw new NullReferenceException();

            return Items.SingleOrDefault(item => item.Id.Equals(id));
        }

        public IEnumerable<T> GetAll()
        {
            return this.Items;
        }

        public void Save(T item)
        {
            if (item == null)
                throw new NullReferenceException("No item was given to save.");

            if (Get(item.Id) != null)
                throw new InvalidOperationException("An item with this Id already exists.");

            Items.Add(item);
        }
    }
}
