namespace SevenDigital.Mapper.Domain.Matching
{
    public class MusicBrainzMatcher : IMatcher
    {
        private readonly IMatcher _successor;

        public MusicBrainzMatcher(IMatcher successor)
        {
            _successor = successor;
        }

        public bool Match(IMatchableMapping currentMapping, IMatchableMapping searchMapping)
        {
            if (!searchMapping.MusicBrainz.Equals(Mapping.NULL_MUSIC_BRAINZ_ID))
                return currentMapping.MusicBrainz.Equals(searchMapping.MusicBrainz);

            return _successor.Match(currentMapping, searchMapping);
        }
    }
}