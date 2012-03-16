using System.Collections.Generic;
using System.Linq;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Persistence
{
    public class Repository : IRepository
    {
        private readonly IEnumerable<IMapping> _list;

        public Repository(IEnumerable<IMapping> list)
        {
            _list = list;
        }

        public IEnumerable<IMapping> ListAll()
        {
            return _list;
        }

        public IMapping GetBy(IMatchableMapping mapping)
        {
            return _list.FirstOrDefault(m => m.Matches(mapping)) ?? new NullMapping();
        }
    }
}
