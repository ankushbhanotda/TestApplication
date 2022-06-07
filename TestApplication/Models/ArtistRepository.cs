using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.ViewModel;

namespace TestApplication.Models
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ArtistRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ArtistVM>> GetArtists()
        {
            var artistList = await _dbContext.Artists.ToListAsync();
            if(artistList !=null)
            {
                var response = new List<ArtistVM>();
                foreach (var art in artistList)
                {
                    response.Add(new ArtistVM() { ArtistId = art.ArtistId, Name = art.Name });
                }
                return response;
            }
            return null;
        }

        public async Task<ArtistVM> GetArtist(int Id)
        {
            if (Id > 0)
            {
                var model = await _dbContext.Artists.FindAsync(Id);
                return _mapper.Map<ArtistVM>(model);
            }
            return null;
        }

        public async Task<ArtistVM> AddArtist(ArtistVM viewmodel)
        {
            if (viewmodel != null)
            {
                var model = _mapper.Map<Artist>(viewmodel);
                _dbContext.Artists.Add(model);
                await _dbContext.SaveChangesAsync();
                viewmodel.ArtistId = model.ArtistId;
                return viewmodel;
            }
            return null;
        }

        public void DeleteArtist(int Id)
        {
            var artist = _dbContext.Artists.Find(Id);
            if (artist != null)
            {
                _dbContext.Artists.Remove(artist);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateArtist(ArtistVM viewmodel)
        {
            if (viewmodel != null)
            {
                var model = _mapper.Map<Artist>(viewmodel);
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }
    }
}
