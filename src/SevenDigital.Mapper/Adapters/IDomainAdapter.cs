using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Adapters
{
    public interface IDomainAdapter {
        IMapping GetDomainObjectFrom(MappingDto dto);
    }
}