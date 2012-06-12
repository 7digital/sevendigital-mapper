using Nancy;
using System;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;

namespace SevenDigital.Mapper.Api
{
    public class MappingModule : NancyModule
    {
        public MappingModule()
        {
			Get["/"] = _ => DateTime.Now.ToString();
        }
		
    }
}
