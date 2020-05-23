using ProjectMusic.Database;
using ProjectMusic.Entities;
using ProjectMusic.Entities.IRepositories;
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
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Albums = new AlbumRepository(_context);
            Artists = new ArtistRepository(_context);
            Genres = new GenreRepository(_context);
            Songs = new SongRepository(_context);
            Users = new UserRepository(_context);
        }

        public IAlbumRepository Albums { get; private set; }
        public IArtistRepository Artists { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public ISongRepository Songs { get; private set; }
        public IUserRepository Users { get; private set; }

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
