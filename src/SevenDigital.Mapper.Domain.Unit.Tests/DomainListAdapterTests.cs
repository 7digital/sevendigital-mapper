using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SevenDigital.Mapper.Adapters;

namespace SevenDigital.Mapper.Domain.Unit.Tests
{
    [TestFixture]
    public class DomainListAdapterTests
    {
        [Test]
        public void EmptyLisOfDtosYieldsEmptyListOfDomainObjects()
        {
            var subject = new DomainListAdapter(new Mock<IDomainAdapter>().Object);
            var result = subject.GetDomainObjectsFor(new List<MappingDto>());
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void AdaptsToADomainObjectForEveryDto()
        {
            var domainAdapter = new Mock<IDomainAdapter>();
            var subject = new DomainListAdapter(domainAdapter.Object);
            var mappingDtos = new List<MappingDto> {
                new MappingDto(),
                new MappingDto()
            };
            subject.GetDomainObjectsFor(mappingDtos);

            domainAdapter.Verify( 
                adapter => adapter.GetDomainObjectFrom(It.IsAny<MappingDto>()), Times.Exactly(mappingDtos.Count)
                );
        }

        [Test]
        public void AddsResultOfAdaptingToAListOfResults()
        {
            var domainAdapter = new Mock<IDomainAdapter>();
            var subject = new DomainListAdapter(domainAdapter.Object);
            var mappingDtos = new List<MappingDto> {
                new MappingDto()
            };

            var mapping = new Mapping { MusicBrainz = new MusicBrainzId("music") };
            domainAdapter.Setup(adapter => adapter.GetDomainObjectFrom(It.IsAny<MappingDto>()))
                .Returns(mapping);
            
            var result = subject.GetDomainObjectsFor(mappingDtos);
            Assert.That(result, Is.EquivalentTo(new List<IMapping> {mapping}));
        }
    }
}