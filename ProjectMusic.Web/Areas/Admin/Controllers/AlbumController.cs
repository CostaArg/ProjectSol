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
using ProjectMusic.Entities.Domain;
using ProjectMusic.Services;
using ProjectMusic.Services.Repositories;

namespace ProjectMusic.Web.Areas.Admin.Controllers
{
    public class AlbumController : Controller
    {
        // private AlbumRepository albumRepository = new AlbumRepository();

        private IUnitOfWork UnitOfWork = new UnitOfWork(new ApplicationDbContext());

       

        // GET: Admin/Album
        public ActionResult Index(string sortOrder, string searchName, int? pSize, int? page)
        {
            var albums = UnitOfWork.Albums.GetAll();

            //Viewbags
            ViewBag.CurrentName = searchName;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";

            //Sorting
            switch (sortOrder)
            {
                case "NameDesc": albums = albums.OrderByDescending(x => x.AlbumName); break;
                default: albums = albums.OrderBy(x => x.AlbumName); break;
            }

            //Filtering First Name
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                albums = albums.Where(x => x.AlbumName.ToUpper().Contains(searchName.ToUpper()));
            }

            int pageSize = pSize ?? 3;
            int pageNumber = page ?? 1;

            return View(albums.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = UnitOfWork.Albums.Get(id);  

            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        // GET: Admin/Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,AlbumName,AlbumPhotoUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Albums.Add(album);
                UnitOfWork.Complete();
               
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Admin/Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = UnitOfWork.Albums.Get(id);

            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        // POST: Admin/Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,AlbumName,AlbumPhotoUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Albums.Update(album);
                UnitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Admin/Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = UnitOfWork.Albums.Get(id);

            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        // POST: Admin/Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = UnitOfWork.Albums.Get(id);
            UnitOfWork.Albums.Remove(album);
            UnitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
