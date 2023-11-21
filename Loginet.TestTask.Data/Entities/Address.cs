using System.Text.Json.Serialization;
using TestTask.Loginet.Data.Interfaces;

namespace TestTask.Loginet.Data.Entities
{
    public class Address : IDbEntity
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }

        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }
}
