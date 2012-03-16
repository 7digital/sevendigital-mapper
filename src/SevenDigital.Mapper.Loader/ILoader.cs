using System.Collections.Generic;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Loader
{
    public interface ILoader {
        IEnumerable<MappingDto> Load(string filePath);
    }
}