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
}
