namespace SevenDigital.Mapper.Domain
{
    public interface IMapping {
        bool Matches(IMatchableMapping searchMapping);
    	IViewModel To(IViewModel view);
    }
}