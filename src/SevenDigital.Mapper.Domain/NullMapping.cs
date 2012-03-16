namespace SevenDigital.Mapper.Domain
{
    public class NullMapping : IMapping {
        public bool Matches(IMatchableMapping searchMapping)
        {
            return false;
        }
    }
}