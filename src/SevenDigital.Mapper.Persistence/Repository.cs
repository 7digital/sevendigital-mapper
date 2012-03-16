using System.Collections.Generic;
using System.Linq;

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

        public IMapping GetBy(Mapping mapping)
        {
            return _list.FirstOrDefault(m => m.Matches(mapping)) ?? new NullMapping();
        }
    }

    public interface IMapping {
        bool Matches(IMatchableMapping mapping);
    }

    public class NullMapping : IMapping {
        public bool Matches(IMatchableMapping mapping)
        {
            return false;
        }
    }

    public interface IMatchableMapping {
        SevenDigitalId SevenDigital { get; set; }
    }

    public class Mapping : IMapping, IMatchableMapping
    {
        public SevenDigitalId SevenDigital { get; set; }
        public bool Matches(IMatchableMapping mapping)
        {
            return SevenDigital.Equals(mapping.SevenDigital);
        }
    }

    public class SevenDigitalId
    {
        private readonly int _id;

        public SevenDigitalId(int id)
        {
            _id = id;
        }

        public bool Equals(SevenDigitalId other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return other._id == _id;
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj.GetType() != typeof(SevenDigitalId))
            {
                return false;
            }
            return Equals((SevenDigitalId) obj);
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}
