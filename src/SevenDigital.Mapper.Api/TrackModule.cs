using Nancy;
using Nancy.ModelBinding;
using System;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;

namespace SevenDigital.Mapper.Api
{
    public class TrackModule : NancyModule
    {
        public TrackModule() : base("/track")
        {
        	var mappingService = new MappingService(new LastFmLoader(), "tracks");
        	Get["/"] = _ => MapResult(mappingService);
        	Post["/"] = _ => MapResult(mappingService);
        }

    	private Response MapResult(MappingService mappingService)
    	{
    		var result = mappingService.Map(Mapping.From(this.Bind<SerializableMapping>()));

    		var viewmodel = new SerializableMapping();
    		return Response.AsJson(result.To(viewmodel));
    	}

    	public class SerializableMapping : IViewModel
		{
			public string MusicBrainz { get; set; }
			public string SevenDigital { get; set; }
		}
    }
}
