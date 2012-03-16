using System.Collections.Generic;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Loader
{
    public interface ITabSeparatedVariableLoader {
        IEnumerable<MappingDto> Load(string filePath);
    }
}