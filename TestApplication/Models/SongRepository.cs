using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.ViewModel;

namespace TestApplication.Models
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public SongRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<SongVM>> GetSongs()
        {
            var songList = await _dbContext.Songs.AsNoTracking()
                             .Include(x => x.Artist)
                             .Include(x => x.Genre)
                             .ToListAsync();

            if(songList != null)
            {
                var response = new List<SongVM>();
                foreach(var s in songList)
                {
                    response.Add(new SongVM() 
                    { 
                        SongId = s.SongId,
                        Name = s.Name,
                        ArtistId = s.Artist.Name,
                        Time = s.Time,
                        Popularity = s.Popularity,
                        Price = s.Price,
                        GenreId = s.Genre.Name
                    });
                }
                return response;
            }
            return null;
        }

        public async Task<SongVM> GetSong(int Id)
        {
            if (Id > 0)
            {
                var model = await _dbContext.Songs.FindAsync(Id);
                return _mapper.Map<SongVM>(model);
            }
            return null;
        }

        public async Task<SongVM> AddSong(SongVM song)
        {
            if (song != null)
            {
                var model = _mapper.Map<Song>(song);
                _dbContext.Songs.Add(model);
               await _dbContext.SaveChangesAsync();
                song.SongId = model.SongId;
                return song;
            }
            return null;
        }

        public void DeleteSong(int Id)
        {
            var model = _dbContext.Songs.Find(Id);
            if (model != null)
            {
                _dbContext.Songs.Remove(model);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateSong(SongVM song)
        {
            if (song != null)
            {
                var model = _mapper.Map<Song>(song);
                _dbContext.Songs.Update(model);
                _dbContext.SaveChanges();
            }
        }
    }
}
