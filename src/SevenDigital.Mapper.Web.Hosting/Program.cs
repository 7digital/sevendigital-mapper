using System;
using Nancy.Hosting.Self;

namespace SevenDigital.Mapper.Web.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            MappingModule mappingModule = new MappingModule();
			var url = "http://localhost:1212";
						
            var host = new NancyHost(new Uri("http://localhost:1212"));
            host.Start();
			Console.WriteLine ("Mapper API running at: " + url);
			Console.WriteLine ("Press the any key to abort");
            Console.ReadKey();
            host.Stop();
			Console.WriteLine ("Host aborted");
        }
    }
}
