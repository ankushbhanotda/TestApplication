using Autofac;

namespace TestApplication.Models
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SongRepository>().As<ISongRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<ArtistRepository>().As<IArtistRepository>();
        }
    }
}
