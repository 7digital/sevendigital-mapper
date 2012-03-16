using System;

namespace SevenDigital.Mapper.Domain
{
    public class SevenDigitalId : ISevenDigitalId
    {
        private readonly int _id;

        public static ISevenDigitalId From(string id)
        {
            try
            {
                var sevenDigitalId = int.Parse(id);
                return new SevenDigitalId(sevenDigitalId);
            }
            catch (ArgumentException argumentException)
            {
                // null id encountered
            }
            catch (FormatException formatException)
            {
                // not a valid id
            }
            catch (OverflowException overflowException)
            {
                // id too large
            }

            return new NullSevenDigitalId();
        }

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

        public override string ToString()
        {
            return string.Format("{0}", _id);
        }
    }

    public class NullSevenDigitalId : ISevenDigitalId {}

    public interface ISevenDigitalId {}
}