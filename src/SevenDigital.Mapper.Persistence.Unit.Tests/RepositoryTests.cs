using System.Collections.Generic;
using NUnit.Framework;

namespace SevenDigital.Mapper.Persistence.Unit.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private Repository _subject;
        private List<IMapping> _loadedList;

        [SetUp]
        public void SetUp()
        {
            _loadedList = new List<IMapping>();
            _subject = new Repository(_loadedList);
        }

        [Test]
        public void ListAllReturnsEntireRepository()
        {
            Assert.That(_subject.ListAll(), Is.SameAs(_loadedList));
        }
        
        [Test]
        public void GetByEmptyMappingReturnsNullMapping()
        {

            Assert.That(_subject.GetBy(new Mapping()), Is.InstanceOf<NullMapping>());
        }
    }


}
