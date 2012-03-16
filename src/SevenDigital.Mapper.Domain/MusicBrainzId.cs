namespace SevenDigital.Mapper.Domain
{
    public class MusicBrainzId
    {
        private readonly string _mbid;

        public MusicBrainzId(string mbid)
        {
            _mbid = mbid;
        }

        public bool Equals(MusicBrainzId other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other._mbid, _mbid);
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
            if(obj.GetType() != typeof(MusicBrainzId))
            {
                return false;
            }
            return Equals((MusicBrainzId) obj);
        }

        public override int GetHashCode()
        {
            return (_mbid != null ?_mbid.GetHashCode() : 0);
        }
    }
}