using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Adapters
{
    public class DomainAdapter {
        public IMapping GetDomainObjectFrom(MappingDto dto)
        {
            var result = new Mapping
            {
                SevenDigital = SevenDigitalId.From(dto.SevenDigital),
                MusicBrainz = new MusicBrainzId(dto.MusicBrainz)
            };
            
            return result;
        }
    }
}
