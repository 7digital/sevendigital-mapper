namespace SevenDigital.Mapper.Domain
{
    public class SevenDigitalId
    {
        private readonly int _id;

        public SevenDigitalId(int id)
        {
            _id = id;
        }

        public bool Equals(SevenDigitalId other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return other._id == _id;
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
            if(obj.GetType() != typeof(SevenDigitalId))
            {
                return false;
            }
            return Equals((SevenDigitalId) obj);
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}