using ProjectMusic.Database;
using ProjectMusic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Services
{
    public class AlbumRepository
    {

        MyDatabase db = new MyDatabase();

        //Get all

        public IEnumerable<Album> GetAll()
        {
            return db.Albums.ToList();
        }

        //Get by id
        public Album GetById(int? id)
        {
            return db.Albums.Find(id);
        }

        //Insert
        public void Insert(Album album)
        {
            db.Entry(album).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update
        public void Update(Album album)
        {
            db.Entry(album).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(Album album)
        {
            db.Entry(album).State = EntityState.Deleted;
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
