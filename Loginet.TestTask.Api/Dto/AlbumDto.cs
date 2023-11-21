using System.IO;
using System.Reflection.Emit;
using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Dto
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }

        public Album MapToDb()
        {
            return new Album()
            {
                Id = Id,
                UserId = UserId,
                Title = Title
            };
        }
    }
}
