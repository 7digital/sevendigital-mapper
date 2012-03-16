using System.Collections.Generic;
using NUnit.Framework;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Persistence.Unit.Tests
{
    [TestFixture]
    public class RepositoryMusicBrainzQueryTests
    {
        private Repository _subject;
        private List<IMapping> _loadedList;
        private MusicBrainzId _musicBrainzId;
        private Mapping _expectedMapping;

        [SetUp]
        public void SetUp()
        {
            _musicBrainzId = new MusicBrainzId("0004006f-14a0-4d3e-ab7c-073ecf8dbf77");
            _expectedMapping = new Mapping
            {
                SevenDigital = new SevenDigitalId(12345),
                MusicBrainz = _musicBrainzId
            };
            _loadedList = new List<IMapping> 
            {
                _expectedMapping
            };
            _subject = new Repository(_loadedList);
        }

        [Test]
        public void GetByMappingWithMusicBrainzlIdReturnsNullMapping()
        {
            Assert.That(_subject.GetBy(new Mapping { MusicBrainz = _musicBrainzId }), Is.SameAs(_expectedMapping));
        }
    }
}