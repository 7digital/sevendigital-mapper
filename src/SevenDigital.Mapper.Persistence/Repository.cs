using System.Collections.Generic;

namespace SevenDigital.Mapper.Persistence
{
    public class Repository
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
    }

    public interface IMapping {}
}
