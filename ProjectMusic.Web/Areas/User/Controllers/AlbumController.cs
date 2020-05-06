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

namespace ProjectMusic.Web.Areas.User.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumRepository albumRepository = new AlbumRepository();

        // GET: User/Album
        public ActionResult Index(string sortOrder, string searchName, int? pSize, int? page)
        {
            var albums = albumRepository.GetAll();

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

        // GET: User/Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = albumRepository.GetById(id);

            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                albumRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
