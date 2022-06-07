using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ViewModel;

namespace TestApplication.Models
{
    public interface IGenreRepository
    {
        Task<List<GenreVM>> GetGenres();
        Task<GenreVM> GetGenre(int Id);
        Task<GenreVM> AddGenre(GenreVM genre);
        void UpdateGenre(GenreVM genre);
        void DeleteGenre(int Id);
    }
}
