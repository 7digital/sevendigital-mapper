using System.Collections.Generic;
using NUnit.Framework;

namespace SevenDigital.Mapper.Persistence.Unit.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void ListAllReturnsEntireRepository()
        {
            var loadedList = new List<IMapping>();
            var subject = new Repository(loadedList);
            Assert.That(subject.ListAll(), Is.SameAs(loadedList));
        }
    }
}
