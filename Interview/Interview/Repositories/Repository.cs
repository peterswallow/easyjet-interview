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
        private Dictionary<I, T> Items; 
        
        public Repository()
        {
            Items = new Dictionary<I, T>();
        }

        public Repository(IEnumerable<T> items)
        {
            this.Items = items.ToDictionary(item => item.Id, item => item);
        }

        public void Delete(I id)
        {
            if (id == null)
                throw new NullReferenceException("The Id provided is null");

            if (!Items.ContainsKey(id))
                throw new InvalidOperationException("The item to delete does not exist.");

            Items.Remove(id);
        }

        public T Get(I id)
        {
            if (id == null)
                throw new NullReferenceException();

            T value;
            Items.TryGetValue(id, out value);
            
            return value;
        }

        public IEnumerable<T> GetAll()
        {
            return Items.Values.ToList();
        }

        public void Save(T item)
        {
            if (item == null)
                throw new NullReferenceException("No item was given to save.");

            if (Items.ContainsKey(item.Id))
                throw new InvalidOperationException("An item with this Id already exists.");

            Items.Add(item.Id, item);
        }
    }
}
