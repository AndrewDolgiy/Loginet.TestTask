using System.Text.Json.Serialization;
using TestTask.Loginet.Data.Interfaces;

namespace TestTask.Loginet.Data.Entities
{
    public class Company : IDbEntity
    {
        public int Id { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}