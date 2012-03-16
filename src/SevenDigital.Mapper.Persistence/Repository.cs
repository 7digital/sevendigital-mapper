using System.Collections.Generic;
using System.Linq;
using SevenDigital.Mapper.Domain;

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
        bool Matches(IMatchableMapping searchMapping);
    }

    public class NullMapping : IMapping {
        public bool Matches(IMatchableMapping searchMapping)
        {
            return false;
        }
    }

    public interface IMatchableMapping {
        SevenDigitalId SevenDigital { get; set; }
        MusicBrainzId MusicBrainz { get; set; }
    }

    public class Mapping : IMapping, IMatchableMapping
    {
        private readonly SevenDigitalId NULL_SEVEN_DIGITAL_ID = new SevenDigitalId(0);
        private readonly MusicBrainzId NULL_MUSIC_BRAINZ_ID = new MusicBrainzId("");

        public Mapping()
        {
            SevenDigital = NULL_SEVEN_DIGITAL_ID;
            MusicBrainz = NULL_MUSIC_BRAINZ_ID;
        }

        public SevenDigitalId SevenDigital { get; set; }

        public MusicBrainzId MusicBrainz { get; set; }

        public bool Matches(IMatchableMapping searchMapping)
        {
            if (!searchMapping.SevenDigital.Equals(NULL_SEVEN_DIGITAL_ID))
                return SevenDigital.Equals(searchMapping.SevenDigital);
            if (!searchMapping.MusicBrainz.Equals(NULL_MUSIC_BRAINZ_ID))
                return MusicBrainz.Equals(searchMapping.MusicBrainz);

            return false;
        }
    }
}
