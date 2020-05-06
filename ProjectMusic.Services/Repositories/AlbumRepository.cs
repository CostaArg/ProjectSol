using ProjectMusic.Database;
using ProjectMusic.Entities;
using ProjectMusic.Entities.Domain;
using ProjectMusic.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Services.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<Album> GetDesc()
        {
            throw new NotImplementedException();
        }
    }
}
