using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
using PagedList;
using ProjectMusic.Database;
using ProjectMusic.Entities;
using ProjectMusic.Entities.Domain;
using ProjectMusic.Services;
using ProjectMusic.Services.Repositories;

namespace ProjectMusic.Web.Areas.Admin.Controllers
{
    public class SongController : Controller
    {
        private IUnitOfWork UnitOfWork = new UnitOfWork(new ApplicationDbContext());

        // GET: Admin/Song
        public ActionResult Index(string sortOrder, string searchName, int? pSize, int? page)
        {
            var songs = UnitOfWork.Songs.GetAll();

            //Viewbags
            ViewBag.CurrentName = searchName;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";

            //Sorting
            switch (sortOrder)
            {
                case "NameDesc": songs = songs.OrderByDescending(x => x.SongName); break;
                default: songs = songs.OrderBy(x => x.SongName); break;
            }

            //Filtering Name
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                songs = songs.Where(x => x.SongName.ToUpper().Contains(searchName.ToUpper()));
            }

            int pageSize = pSize ?? 3;
            int pageNumber = page ?? 1;

            return View(songs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Song/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Song song = UnitOfWork.Songs.Get(id);

            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Admin/Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Song/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongId,SongName")] Song song)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Songs.Add(song);
                UnitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(song);
        }

        // GET: Admin/Song/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Song song = UnitOfWork.Songs.Get(id);

            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Admin/Song/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongId,SongName")] Song song)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Songs.Update(song);
                UnitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(song);
        }

        // GET: Admin/Song/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Song song = UnitOfWork.Songs.Get(id);

            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Admin/Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = UnitOfWork.Songs.Get(id);
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
