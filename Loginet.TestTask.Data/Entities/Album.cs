using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TestTask.Loginet.Data.Interfaces;

namespace TestTask.Loginet.Data.Entities
{
    public class Album : IDbEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}
