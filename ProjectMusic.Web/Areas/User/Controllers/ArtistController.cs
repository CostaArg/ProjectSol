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

namespace ProjectMusic.Web.Areas.User.Controllers
{
    public class ArtistController : Controller
    {
        private IUnitOfWork UnitOfWork = new UnitOfWork(new MyDatabase());

        // GET: User/Artist
        public ActionResult Index(string sortOrder, string searchName, int? pSize, int? page)
        {
            var artists = UnitOfWork.Artists.GetAll();

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

        // GET: User/Artist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artist artist = UnitOfWork.Artists.Get(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
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
