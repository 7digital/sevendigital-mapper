using System.Collections.Generic;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Adapters
{
    public class DomainListAdapter {
        public IEnumerable<IMapping> GetDomainObjectsFor(IEnumerable<MappingDto> mappingDtos)
        {
            return new List<IMapping>();
        }
    }
}