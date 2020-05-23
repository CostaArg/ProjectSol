using ProjectMusic.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Entities
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository Albums { get; }
        ISongRepository Songs { get; }
        IGenreRepository Genres { get; }
        IArtistRepository Artists { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
