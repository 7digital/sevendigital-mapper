using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Api
{
	public class SerializableMapping : IViewModel
	{
		public string MusicBrainz { get; set; }
		public string SevenDigital { get; set; }
	}
}