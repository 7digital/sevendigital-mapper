using Nancy;
using Nancy.ModelBinding;
using System;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;

namespace SevenDigital.Mapper.Api
{
    public class MappingModule : NancyModule
    {
        public MappingModule()
        {
        	var mappingService = new MappingService(new LastFmLoader());
        	Post["/"] = _ =>
        		{
        			var result = mappingService.Map(Mapping.From(this.Bind<SerializableMapping>()));
        			
					var viewmodel = new SerializableMapping();
					return Response.AsJson(result.To(viewmodel));
        		};
        
			Get["/"] = _ => DateTime.Now.ToString();
        }

		public class SerializableMapping : IViewModel
		{
			public string MusicBrainz { get; set; }
			public string SevenDigital { get; set; }
		}
    }
}
