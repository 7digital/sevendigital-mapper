using System;
using Nancy.Hosting.Self;

namespace SevenDigital.Mapper.Web.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            MappingModule mappingModule = new MappingModule();
            var host = new NancyHost(new Uri("http://localhost:1212"));
            host.Start();

            Console.ReadKey();
            host.Stop();
        }
    }
}
