using System.ComponentModel.DataAnnotations.Schema;
using TestTask.Loginet.Data.Interfaces;

namespace TestTask.Loginet.Data.Entities
{
    public class User : IDbEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        
        public Company Company { get; set; }
        public Address Address { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}