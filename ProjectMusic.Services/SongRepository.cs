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
    public class SongRepisitory
    {

        MyDatabase db = new MyDatabase();

        //Get all

        public IEnumerable<Song> GetAll()
        {
            return db.Songs.ToList();
        }

        //Get by id
        public Song GetById(int? id)
        {
            return db.Songs.Find(id);
        }

        //Insert
        public void Insert(Song song)
        {
            db.Entry(song).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update
        public void Update(Song song)
        {
            db.Entry(song).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(Song song)
        {
            db.Entry(song).State = EntityState.Deleted;
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
