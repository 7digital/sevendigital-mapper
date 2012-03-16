namespace SevenDigital.Mapper.Domain
{
    public interface IMatchableMapping {
        SevenDigitalId SevenDigital { get; set; }
        MusicBrainzId MusicBrainz { get; set; }
    }
}