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
    public class GenreRepository
    {

        MyDatabase db = new MyDatabase();

        //Get all

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        //Get by id
        public Genre GetById(int? id)
        {
            return db.Genres.Find(id);
        }

        //Insert
        public void Insert(Genre genre)
        {
            db.Entry(genre).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update
        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(Genre genre)
        {
            db.Entry(genre).State = EntityState.Deleted;
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
