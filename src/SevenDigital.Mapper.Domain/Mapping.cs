namespace SevenDigital.Mapper.Domain
{
    public class Mapping : IMapping, IMatchableMapping
    {
        public static readonly SevenDigitalId NULL_SEVEN_DIGITAL_ID = new SevenDigitalId(0);
        public static readonly MusicBrainzId NULL_MUSIC_BRAINZ_ID = new MusicBrainzId("");

        public Mapping()
        {
            SevenDigital = NULL_SEVEN_DIGITAL_ID;
            MusicBrainz = NULL_MUSIC_BRAINZ_ID;
        }

        public SevenDigitalId SevenDigital { get; set; }

        public MusicBrainzId MusicBrainz { get; set; }

        public bool Matches(IMatchableMapping searchMapping)
        {
            return new SevenDigitalMatcher(new MusicBrainzMatcher(new NeverMatcher()))
                .Match(this, searchMapping);
        }
    }

    public class SevenDigitalMatcher : IMatcher
    {
        private readonly IMatcher _successor;

        public SevenDigitalMatcher(IMatcher successor)
        {
            _successor = successor;
        }

        public bool Match(IMatchableMapping currentMapping, IMatchableMapping searchMapping)
        {
            if (!searchMapping.SevenDigital.Equals(Mapping.NULL_SEVEN_DIGITAL_ID))
                return currentMapping.SevenDigital.Equals(searchMapping.SevenDigital);

            return _successor.Match(currentMapping, searchMapping);
        }
    }

    public class MusicBrainzMatcher : IMatcher
    {
        private readonly IMatcher _successor;

        public MusicBrainzMatcher(IMatcher successor)
        {
            _successor = successor;
        }

        public bool Match(IMatchableMapping currentMapping, IMatchableMapping searchMapping)
        {
            if (!searchMapping.MusicBrainz.Equals(Mapping.NULL_MUSIC_BRAINZ_ID))
                return currentMapping.MusicBrainz.Equals(searchMapping.MusicBrainz);

            return _successor.Match(currentMapping, searchMapping);
        }
    }

    public class NeverMatcher : IMatcher
    {
        public bool Match(IMatchableMapping currentMapping, IMatchableMapping searchMapping)
        {
            return false;
        }
    }

    public interface IMatcher {
        bool Match(IMatchableMapping currentMapping, IMatchableMapping searchMapping);
    }
}