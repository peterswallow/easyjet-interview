using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Repository<T, I> : IRepository<T, I>
        where T : IStoreable<I>

    {
        private IEnumerable<T> Items; 
        
        public Repository()
        {

        }

        public Repository(IEnumerable<T> items)
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
            throw new NotImplementedException();
        }
    }
}
