﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SevenDigital.Mapper.Domain.Unit.Tests
{
    [TestFixture]
    public class DomainAdapterTests
    {
        [Test]
        public void ShouldCreateDomainObjectFromDto()
        {
            const string musicBrainzId = "000b99c6-0f38-462f-8231-44ee44cff0ed";
            var dto = new MappingDto
            {
                SevenDigital = "123456",
                MusicBrainz = musicBrainzId
            };
            var subject = new DomainAdapter();
            Assert.That(subject.GetDomainObjectFrom(dto), Is.EqualTo(new Mapping {
                SevenDigital = new SevenDigitalId(123456),
                MusicBrainz = new MusicBrainzId(musicBrainzId)
            }));
        }
    }

    public class DomainAdapter {
        public IMapping GetDomainObjectFrom(MappingDto dto)
        {
            var result = new Mapping
            {
                SevenDigital = SevenDigitalId.From(dto.SevenDigital),
                MusicBrainz = new MusicBrainzId(dto.MusicBrainz)
            };
            
            return result;
        }
    }
}
