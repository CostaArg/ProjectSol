using ProjectMusic.Database;
using ProjectMusic.Services.IRepositories;
using ProjectMusic.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDatabase _context;

        public UnitOfWork(MyDatabase context)
        {
            _context = context;
            Albums = new AlbumRepository(_context);
            Artists = new ArtistRepository(_context);
            Genres = new GenreRepository(_context);
            Songs = new SongRepository(_context);
        }

        public IAlbumRepository Albums { get; private set; }
        public IArtistRepository Artists { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public ISongRepository Songs { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
