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
    public class ArtistRepository
    {

        MyDatabase db = new MyDatabase();

        //Get all

        public IEnumerable<Artist> GetAll()
        {
            return db.Artists.ToList();
        }

        //Get by id
        public Artist GetById(int? id)
        {
            return db.Artists.Find(id);
        }

        //Insert
        public void Insert(Artist artist)
        {
            db.Entry(artist).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update
        public void Update(Artist artist)
        {
            db.Entry(artist).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(Artist artist)
        {
            db.Entry(artist).State = EntityState.Deleted;
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
