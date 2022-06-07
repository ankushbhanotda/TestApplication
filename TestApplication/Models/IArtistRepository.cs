using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ViewModel;

namespace TestApplication.Models
{
    public interface IArtistRepository
    {
        Task<List<ArtistVM>> GetArtists();
        Task<ArtistVM> GetArtist(int Id);
        Task<ArtistVM> AddArtist(ArtistVM artist);
        void UpdateArtist(ArtistVM artist);
        void DeleteArtist(int Id);
    }
}
