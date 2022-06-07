using AutoMapper;
using TestApplication.Models;
using TestApplication.ViewModel;

namespace TestApplication.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "AutoMapperProfile";
            }
        }
        public AutoMapperProfile()
        {
            ConfigureMappings();
        }
        private void ConfigureMappings()
        {
            CreateMap<Artist, ArtistVM>().ReverseMap();
            CreateMap<Genre, GenreVM>().ReverseMap();
            CreateMap<Song, SongVM>().ReverseMap();
        }
    }
}
