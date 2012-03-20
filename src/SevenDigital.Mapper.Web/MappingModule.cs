using Nancy;
using Nancy.Responses;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;
using SevenDigital.Mapper.Unit.Tests;
using System;

namespace SevenDigital.Mapper.Web
{
    public class MappingModule : NancyModule
    {
        public MappingModule()
        {
            var mappingService = new MappingService(new LastFmLoader());
            Get["/mbid/{Mbid}"] = req =>
                                  {
                                      var result = mappingService.Map(new Mapping { MusicBrainz = new MusicBrainzId(req.Mbid) });

                                      return((Mapping) result).SevenDigital.ToString();
                                  };

            Get["/7did/{Id}"] = req =>
            {
                                    var result = mappingService.Map(new Mapping { SevenDigital = new SevenDigitalId(req.Id) });
                                    return
                                      Response.AsRedirect(
                                          "http://www.last.fm/mbid/"
                                          +
                                          ((Mapping)result).MusicBrainz.ToString
                                              ());
                                                                       
                                };
			Get["/status"] = _ => DateTime.Now.ToString();
        }
		
    }
}
