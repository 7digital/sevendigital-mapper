using System.Collections.Generic;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Persistence
{
    public interface IRepository {
        IEnumerable<IMapping> ListAll();
        IMapping GetBy(IMatchableMapping mapping);
    }
}