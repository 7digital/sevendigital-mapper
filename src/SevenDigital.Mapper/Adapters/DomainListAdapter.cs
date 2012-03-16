using System.Collections.Generic;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Adapters
{
    public class DomainListAdapter {
        private readonly IDomainAdapter _domainAdapter;

        public DomainListAdapter(IDomainAdapter domainAdapter)
        {
            _domainAdapter = domainAdapter;
        }

        public IEnumerable<IMapping> GetDomainObjectsFor(IEnumerable<MappingDto> mappingDtos)
        {
            var result = new List<IMapping>();

            foreach(var dto in mappingDtos)
                result.Add(_domainAdapter.GetDomainObjectFrom(dto));

            return result;
        }
    }
}