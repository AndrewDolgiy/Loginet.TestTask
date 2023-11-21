using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Interfaces
{
    public interface IAlbumService
    {
        Task<Album> GetAlbumById(int Id);
        Task<List<Album>> GetAlbums();
        Task<List<Album>> GetUserAlbums(int Id);
    }
}