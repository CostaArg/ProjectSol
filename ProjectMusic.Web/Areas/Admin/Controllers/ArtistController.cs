﻿using System;
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
    public class ArtistController : Controller
    {
        private ArtistRepository artistRepository = new ArtistRepository();

        // GET: Admin/Artist
        public ActionResult Index(string sortOrder, string searchName, int? pSize, int? page)
        {
            var artists = artistRepository.GetAll();

            //Viewbags
            ViewBag.CurrentName = searchName;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";

            //Sorting
            switch (sortOrder)
            {
                case "NameDesc": artists = artists.OrderByDescending(x => x.ArtistName); break;
                default: artists = artists.OrderBy(x => x.ArtistName); break;
            }

            //Filtering Name
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                artists = artists.Where(x => x.ArtistName.ToUpper().Contains(searchName.ToUpper()));
            }

            int pageSize = pSize ?? 3;
            int pageNumber = page ?? 1;

            return View(artists.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Artist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artist artist = artistRepository.GetById(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }

        // GET: Admin/Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Artist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistId,ArtistName,ArtistPhotoUrl")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                artistRepository.Insert(artist);
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Admin/Artist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artist artist = artistRepository.GetById(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }

        // POST: Admin/Artist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistId,ArtistName,ArtistPhotoUrl")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                artistRepository.Update(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Admin/Artist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artist artist = artistRepository.GetById(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }

        // POST: Admin/Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = artistRepository.GetById(id);
            artistRepository.Delete(artist);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                artistRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
