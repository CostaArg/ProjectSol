using ProjectMusic.Entities;
using ProjectMusic.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Entities.IRepositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        IEnumerable<Album> GetAlbumsWithSongs();
        void UpdateSpotify(Album album);
    }
}
