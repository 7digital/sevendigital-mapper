namespace SevenDigital.Mapper.Domain.Matching
{
    public interface IMatcher {
        bool Match(IMatchableMapping currentMapping, IMatchableMapping searchMapping);
    }
}