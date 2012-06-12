using System;
using System.IO;
using System.Reflection;
using SevenDigital.Mapper.Adapters;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;
using SevenDigital.Mapper.Persistence;

namespace SevenDigital.Mapper
{
    public class MappingService {
        private readonly ILoader _loader;
    	private string _tracks;

    	public MappingService(ILoader loader, string tracks)
        {
            _loader = loader;
			_tracks = tracks;
        }

        public IMapping Map(IMatchableMapping mapping)
        {
			var pathToAssembly = Assembly.GetAssembly(GetType()).CodeBase.Replace(@"file:///", "");


        	
        	var trackFilePath = Path.Combine(new DirectoryInfo(pathToAssembly).Parent.Parent.FullName, "App_Data", _tracks + ".query.tsv");
			var dtos = _loader.Load(trackFilePath);
            var mappings =
                new DomainListAdapter(new DomainAdapter()).GetDomainObjectsFor(dtos);
            var repo = new Repository(mappings);
            return repo.GetBy(mapping);
        }
    }
}