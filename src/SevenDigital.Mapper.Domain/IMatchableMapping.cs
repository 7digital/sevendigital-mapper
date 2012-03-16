namespace SevenDigital.Mapper.Domain
{
    public interface IMatchableMapping {
        ISevenDigitalId SevenDigital { get; set; }
        MusicBrainzId MusicBrainz { get; set; }
    }
}