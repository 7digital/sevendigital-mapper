using SevenDigital.Mapper.Adapters;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;
using SevenDigital.Mapper.Persistence;

namespace SevenDigital.Mapper
{
    public class MappingService {
        private readonly ILoader _loader;

        public MappingService(ILoader loader)
        {
            _loader = loader;
        }

        public IMapping Map(IMatchableMapping mapping)
        {
            var dtos = _loader.Load(@"C:\work\albums.query.tsv");
            var mappings =
                new DomainListAdapter(new DomainAdapter()).GetDomainObjectsFor(dtos);
            var repo = new Repository(mappings);
            return repo.GetBy(mapping);
        }
    }
}