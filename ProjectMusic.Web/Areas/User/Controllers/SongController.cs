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

namespace ProjectMusic.Web.Areas.User.Controllers
{
    public class SongController : Controller
    {
        private SongRepository songRepository = new SongRepository();

        // GET: User/Song
        public ActionResult Index(string sortOrder, string searchName, int? pSize, int? page)
        {
            var songs = songRepository.GetAll();

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

        // GET: User/Song/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Song song = songRepository.GetById(id);

            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                songRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
