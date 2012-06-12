using System.Runtime.Serialization;

namespace SevenDigital.Mapper.Domain
{
    public class MusicBrainzId
    {
        private readonly string _mbid;

        public MusicBrainzId(string mbid)
        {
            _mbid = mbid;
        }

    	public string Mbid
    	{
    		get { return _mbid; }
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
            return Equals(other.Mbid, Mbid);
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
            return (Mbid != null ?Mbid.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Mbid;
        }


    }


}