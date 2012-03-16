using System.Collections.Generic;
using System.IO;
using System.Linq;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Loader
{
    public class LastFmLoader : ITabSeparatedVariableLoader
    {
        public IEnumerable<MappingDto> Load(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Select(line =>
                        {
                            var split = line.Split('\t');

                            return new MappingDto
                            {
                                MusicBrainz = split[0],
                                SevenDigital = split[1],
                                Url = split[2]
                            };
                        });
        }
    }
}
