namespace Radiola.Services.Pandora
{
    public interface IGenreStation
    {
        string StationID { get; set; }
        string StationToken { get; set; }
        string StationName { get; set; }
    }
}