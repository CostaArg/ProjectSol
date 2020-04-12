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
    public class GenreController : Controller
    {
        private GenreRepository genreRepository = new GenreRepository();

        // GET: User/Genre
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

        // GET: User/Genre/Details/5
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
