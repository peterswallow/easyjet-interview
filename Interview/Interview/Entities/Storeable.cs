using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Entities
{
    public class Storeable<T> : IStoreable<T>
    {
        public T Id { get; set; }
    }
}
