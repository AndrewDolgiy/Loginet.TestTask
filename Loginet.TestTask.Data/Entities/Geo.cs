using System.Text.Json.Serialization;
using TestTask.Loginet.Data.Interfaces;

namespace TestTask.Loginet.Data.Entities
{
    public class Geo : IDbEntity
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Address Address { get; set; }
        public int AddressId { get; set; }

        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}