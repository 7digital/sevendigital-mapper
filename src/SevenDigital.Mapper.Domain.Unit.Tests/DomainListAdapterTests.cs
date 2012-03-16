using System.Collections.Generic;
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
            var subject = new DomainListAdapter();
            var result = subject.GetDomainObjectsFor(new List<MappingDto>());
            Assert.That(result, Is.Empty);
        }
    }
}