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

        public ActionResult GetTopFiveAlbums()
        {
            var albums = UnitOfWork.Albums.GetAlbumsWithSongs();

            var topFiveAlbums = albums.OrderByDescending(x=>x.AlbumPurchases).Take(5).Select(x => new { x.AlbumName, x.AlbumPurchases });

            return Json(topFiveAlbums, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetTopFiveUsers()
        {
            var users = UnitOfWork.Users.GetAll();

            var topFiveUsers = users.OrderByDescending(x => x.Orders.Count).Select(x=> new { x.UserName, x.Orders.Count });
        

            return Json(topFiveUsers, JsonRequestBehavior.AllowGet);
        }

    }
}