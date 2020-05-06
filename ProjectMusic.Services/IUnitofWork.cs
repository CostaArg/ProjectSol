using ProjectMusic.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository Albums { get; }
        ISongRepository Songs { get; }
        IGenreRepository Genres { get; }
        IArtistRepository Artists { get; }
        int Complete();
    }
}
