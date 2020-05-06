using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProjectMusic.Database;
using ProjectMusic.Entities;
using ProjectMusic.Services;
using ProjectMusic.Services.Repositories;

namespace ProjectMusic.Web.Areas.Admin.Controllers
{
    public class GenreController : Controller
    {
        private GenreRepository genreRepository = new GenreRepository();

        // GET: Admin/Genre
        public ActionResult Index(string sortOrder, string searchName, int? pSize, int? page)
        {
            var genres = genreRepository.GetAll();

            //Viewbags
            ViewBag.CurrentName = searchName;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";

            //Sorting
            switch (sortOrder)
            {
                case "NameDesc": genres = genres.OrderByDescending(x => x.GenreName); break;
                default: genres = genres.OrderBy(x => x.GenreName); break;
            }

            //Filtering First Name
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                genres = genres.Where(x => x.GenreName.ToUpper().Contains(searchName.ToUpper()));
            }

            int pageSize = pSize ?? 3;
            int pageNumber = page ?? 1;

            return View(genres.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = genreRepository.GetById(id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Admin/Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,GenreName,GenrePhotoUrl")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreRepository.Insert(genre);
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Admin/Genre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = genreRepository.GetById(id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Admin/Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,GenreName,GenrePhotoUrl")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreRepository.Update(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Admin/Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = genreRepository.GetById(id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Admin/Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = genreRepository.GetById(id);
            genreRepository.Delete(genre);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                genreRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
