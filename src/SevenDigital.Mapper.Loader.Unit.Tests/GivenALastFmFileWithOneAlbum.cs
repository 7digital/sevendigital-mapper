using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SevenDigital.Mapper.Domain;

namespace SevenDigital.Mapper.Loader.Unit.Tests
{
    [TestFixture]
    public class GivenALastFmFileWithOneAlbum
    {
        private IEnumerable<MappingDto> _result;

        [TestFixtureSetUp]
        public void WhenParsingIntoObjects()
        {
            var subject = new LastFmLoader();
            _result = subject.Load("res/single_album.tsv");
        }

        [Test]
        public void ThenTheMusicBrainzIdIsSet()
        {
            Assert.That(_result.First().MusicBrainz, Is.EqualTo("00005636-e76b-41d1-a371-8887afe19900"));
        }

        [Test]
        public void ThenTheSevenDigitalIdIsSet()
        {
            Assert.That(_result.First().SevenDigital, Is.EqualTo("708889"));
        }

        [Test]
        public void ThenTheUrlsSet()
        {
            Assert.That(_result.First().Url, Is.EqualTo("http://es.7digital.com/artists/ea/la-vida/?addtobasket=true&partner=264"));
        }
    }
}
