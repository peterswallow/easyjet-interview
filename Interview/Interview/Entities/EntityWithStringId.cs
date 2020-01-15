using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Entities
{
    public class EntityWithStringId : IStoreable<string>
    {
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
