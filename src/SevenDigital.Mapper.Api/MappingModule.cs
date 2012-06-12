using Nancy;
using System;

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
