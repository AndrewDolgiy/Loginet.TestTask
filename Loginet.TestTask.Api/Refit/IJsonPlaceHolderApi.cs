using Loginet.TestTask.Api.Dto;
using Refit;

namespace Loginet.TestTask.Api.Services
{
    public interface IJsonPlaceHolderApi
    {
        [Get("/users")]
        public Task<List<UserDto>> GetUsers();

        [Get("/users/{id}")]
        public Task<UserDto> GetUser(int id);

        [Get("/albums")]
        public Task<List<AlbumDto>> GetAlbums();

        [Get("/albums/{id}")]
        public Task<AlbumDto> GetAlbumById(int id);

        [Get("/albums?userId={id}")]
        public Task<List<AlbumDto>> GetUserAlbums(int id);
    }
}