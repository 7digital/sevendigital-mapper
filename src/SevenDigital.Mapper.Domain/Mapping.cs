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

        public ISevenDigitalId SevenDigital { get; set; }

        public MusicBrainzId MusicBrainz { get; set; }

        public bool Matches(IMatchableMapping searchMapping)
        {
            return new SevenDigitalMatcher(new MusicBrainzMatcher(new NeverMatcher()))
                .Match(this, searchMapping);
        }

        public bool Equals(Mapping other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.SevenDigital, SevenDigital) && Equals(other.MusicBrainz, MusicBrainz);
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj.GetType() != typeof(Mapping))
            {
                return false;
            }
            return Equals((Mapping) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((SevenDigital != null ?SevenDigital.GetHashCode() : 0) * 397) ^ (MusicBrainz != null ?MusicBrainz.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return string.Format("SevenDigital: {0}, MusicBrainz: {1}", SevenDigital, MusicBrainz);
        }
    }
}