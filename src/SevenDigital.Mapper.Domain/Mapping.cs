namespace SevenDigital.Mapper.Domain
{
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