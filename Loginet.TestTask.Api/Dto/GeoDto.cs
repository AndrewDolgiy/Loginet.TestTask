using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Dto
{
    public class GeoDto
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public Geo MapToDb()
        {
            return new Geo()
            {
                Lat = Lat,
                Lng = Lng
            };
        }
    }
}