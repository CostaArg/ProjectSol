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

            var orders = UnitOfWork.Orders.GetAll();

            StatsViewModel vm = new StatsViewModel();

            vm.Albums = albums.ToList();
            vm.Users = users.ToList();
            vm.Orders = orders.ToList();

            return View(vm);
        }

        public ActionResult GetTopFiveAlbums()
        {
            var albums = UnitOfWork.Albums.GetAlbumsWithSongs();

            var topFiveAlbums = albums.OrderByDescending(x=>x.AlbumPurchases).Take(5).Select(x => new { x.AlbumName, x.AlbumPurchases });

            return Json(topFiveAlbums, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetTopThreeUsers()
        {
            var users = UnitOfWork.Users.GetAll();

            var topThreeUsers = users.OrderByDescending(x => x.Orders.Count).Take(3).Select(x=> new { x.UserName, x.Orders.Count });

            return Json(topThreeUsers, JsonRequestBehavior.AllowGet);
        }
    }
}