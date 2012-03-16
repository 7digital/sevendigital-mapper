namespace SevenDigital.Mapper.Domain.Matching
{
    public class NeverMatcher : IMatcher
    {
        public bool Match(IMatchableMapping currentMapping, IMatchableMapping searchMapping)
        {
            return false;
        }
    }
}