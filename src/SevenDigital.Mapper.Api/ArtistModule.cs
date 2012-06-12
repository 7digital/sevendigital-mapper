using Nancy;
using Nancy.ModelBinding;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;

namespace SevenDigital.Mapper.Api
{
	public class ArtistModule : NancyModule
	{
		public ArtistModule()
			: base("/artist")
		{
			var mappingService = new MappingService(new LastFmLoader(), "artists");
			Get["/"] = _ => MapUsing(mappingService);
			Post["/"] = _ => MapUsing(mappingService);
		}

		private Response MapUsing(MappingService mappingService)
		{
			var result = mappingService.Map(Mapping.From(this.Bind<SerializableMapping>()));

			var viewmodel = new SerializableMapping();
			return Response.AsJson(result.To(viewmodel));
		}
	}
}