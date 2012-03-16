using Moq;
using NUnit.Framework;
using SevenDigital.Mapper.Domain;
using SevenDigital.Mapper.Loader;

namespace SevenDigital.Mapper.Unit.Tests
{
    [TestFixture]
    public class MappingServiceTests
    {
        [Test]
        public void ServiceLoadsFromFile()
        {
            var loader = new Mock<ILoader>();
            var subject = new MappingService(loader.Object);
            var result = subject.Map(new Mapping());
            loader.Verify( l => l.Load(It.IsAny<string>()));
        }
    }

    public class MappingService {
        private readonly ILoader _loader;

        public MappingService(ILoader loader)
        {
            _loader = loader;
        }

        public IMapping Map(IMapping mapping)
        {
            var dtos = _loader.Load(@"C:\work\albums.query.tsv");
            return new NullMapping();
        }
    }
}
