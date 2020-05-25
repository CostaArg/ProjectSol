using ProjectMusic.Database;
using ProjectMusic.Entities;
using ProjectMusic.Services;
using ProjectMusic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMusic.Web.Areas.Admin.Controllers
{

    public class AdminStatsController : Controller
    {
        private IUnitOfWork UnitOfWork = new UnitOfWork(new ApplicationDbContext());

        public ActionResult Index()
        {
            var albums = UnitOfWork.Albums.GetAlbumsWithSongs();

            var users = UnitOfWork.Users.GetAll();

            StatsViewModel vm = new StatsViewModel();

            vm.Albums = albums.ToList();
            vm.Users = users.ToList();

            return View(vm);
        }

        public ActionResult GetData()
        {
            var albums = UnitOfWork.Albums.GetAlbumsWithSongs();

            var selection = albums.Select(x => new { x.AlbumName, x.AlbumPurchases });

            return Json(selection, JsonRequestBehavior.AllowGet);
        }
    }
}