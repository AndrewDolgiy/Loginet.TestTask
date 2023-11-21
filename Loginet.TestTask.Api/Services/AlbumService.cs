using Loginet.TestTask.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestTask.Loginet.Data.Database;
using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Services
{
    public class AlbumService : IAlbumService
    {
        private AppDbContext _context;
        private IUserService _userService;
        private IJsonPlaceHolderApi _api;

        public AlbumService(IJsonPlaceHolderApi api, AppDbContext context, IUserService userService)
        {
            _api = api;
            _context = context;
            _userService = userService;
        }

        public async Task<List<Album>> GetAlbums()
        {
            var dbAlbums = await _context.Albums.ToListAsync();
            if (dbAlbums.Count() == 0)
            {
                dbAlbums = await UpdateDbAllAlbumsFromApi();
            }

            return dbAlbums;
        }
        private async Task<List<Album>> UpdateDbAllAlbumsFromApi()
        {
            var albums = await _api.GetAlbums();

            var usersIds = albums.Select(x => x.UserId).ToList();
            await _userService.AddNewUsersById(usersIds);

            var newAlbums = new List<Album>();
            if (albums.Count != 0)
            {
                newAlbums = albums.Select(x => x.MapToDb()).ToList();
                await _context.Albums.AddRangeAsync(newAlbums);
                await _context.SaveChangesAsync();
            }
            return newAlbums;
        }


        public async Task<List<Album>> GetUserAlbums(int Id)
        {
            var dbAlbums = await _context.Albums.Where(x => x.UserId == Id).ToListAsync();
            if (dbAlbums.Count == 0)
            {
                dbAlbums = await UpdateDbUserAlbumsFromApi(Id);
            }

            return dbAlbums;
        }
        private async Task<List<Album>> UpdateDbUserAlbumsFromApi(int Id)
        {
            var albums = await _api.GetUserAlbums(Id);
            var user = await _userService.GetUserById(Id);

            var newAlbums = new List<Album>();
            if (albums.Count != 0)
            {
                newAlbums = albums.Select(x => x.MapToDb()).ToList();
                await _context.Albums.AddRangeAsync(newAlbums);
                await _context.SaveChangesAsync();
            }
            return newAlbums;
        }


        public async Task<Album> GetAlbumById(int Id)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(x => x.Id == Id);
            if (album == null)
            {
                album = await UpdateDbUserAlbumFromApi(Id);
            }
            return album;
        }
        private async Task<Album> UpdateDbUserAlbumFromApi(int Id)
        {
            var newAlbum = await _api.GetAlbumById(Id);
            await _userService.GetUserById(newAlbum.UserId);
            if (newAlbum == null)
            {
                throw new ArgumentNullException(nameof(newAlbum));
            }
            var album = newAlbum.MapToDb();
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();

            return album;
        }
    }
}
