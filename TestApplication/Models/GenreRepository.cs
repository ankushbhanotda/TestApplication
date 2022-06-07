using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.ViewModel;

namespace TestApplication.Models
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GenreRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GenreVM>> GetGenres()
        {
            var genreList = _dbContext.Genres.ToListAsync();
            if (genreList != null)
            {
                var response = new List<GenreVM>();
                foreach (var art in await genreList)
                {
                    response.Add(new GenreVM() { GenreId = art.GenreId, Name = art.Name });
                }
                return response;
            }
            return null;
        }

        public async Task<GenreVM> GetGenre(int Id)
        {
            if (Id > 0)
            {
                var model = await _dbContext.Genres.FindAsync(Id);
                return _mapper.Map<GenreVM>(model);
            }
            return null;
        }

        public async Task<GenreVM> AddGenre(GenreVM viewmodel)
        {
            if(viewmodel != null)
            {
                var model = _mapper.Map<Genre>(viewmodel);
                _dbContext.Genres.Add(model);
                await _dbContext.SaveChangesAsync();
                viewmodel.GenreId = model.GenreId;
                return viewmodel;
            }
            return null;
        }

        public void DeleteGenre(int Id)
        {
            var model = _dbContext.Genres.Find(Id);
            if (model != null)
            {
                _dbContext.Genres.Remove(model);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateGenre(GenreVM viewmodel)
        {
            var model = _mapper.Map<Genre>(viewmodel);
            if (model != null)
            {
                _dbContext.Genres.Update(model);
                _dbContext.SaveChanges();
            }
        }
    }
}
