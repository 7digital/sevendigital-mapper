using Nancy;
using Nancy.ModelBinding;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;

namespace SevenDigital.Mapper.Api
{
    public class TrackModule : NancyModule
    {
        public TrackModule() : base("/track")
        {
        	var mappingService = new MappingService(new LastFmLoader(), "tracks");
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
