namespace SevenDigital.Mapper.Domain
{
    public class NullMapping : IMapping {
        public bool Matches(IMatchableMapping searchMapping)
        {
            return false;
        }

    	public IViewModel To(IViewModel view)
    	{
    		return view;
    	}
    }
}