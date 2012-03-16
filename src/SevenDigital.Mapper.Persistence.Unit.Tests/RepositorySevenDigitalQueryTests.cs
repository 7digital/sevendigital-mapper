using System.Collections.Generic;
using NUnit.Framework;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Persistence.Unit.Tests
{
    [TestFixture]
    public class RepositorySevenDigitalQueryTests
    {
        private Repository _subject;
        private List<IMapping> _loadedList;
        private SevenDigitalId _sevenDigitalId;
        private Mapping _expectedMapping;

        [SetUp]
        public void SetUp()
        {
            _sevenDigitalId = new SevenDigitalId(132456);
            _expectedMapping = new Mapping 
            {
                SevenDigital = _sevenDigitalId
            };
            _loadedList = new List<IMapping> 
            {
                _expectedMapping
            };
            _subject = new Repository(_loadedList);
        }

        [Test]
        public void GetByMappingWithSevenDigitalIdFindsBasedOnSevenDigitalId()
        {
            Assert.That(_subject.GetBy(new Mapping { SevenDigital = _sevenDigitalId }), Is.SameAs(_expectedMapping));
        }
    }
}