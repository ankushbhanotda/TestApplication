using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ViewModel;

namespace TestApplication.Models
{
    public interface ISongRepository
    {
        Task<List<SongVM>> GetSongs();
        Task<SongVM> GetSong(int Id);
        Task<SongVM> AddSong(SongVM song);
        void UpdateSong(SongVM song);
        void DeleteSong(int Id);
    }
}
