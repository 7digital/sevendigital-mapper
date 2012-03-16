namespace SevenDigital.Mapper.Domain.Matching
{
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
}