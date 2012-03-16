using SevenDigital.Mapper.Domain.Matching;

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
}