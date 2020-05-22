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

            StatsViewModel vm = new StatsViewModel();

            vm.Albums = albums.ToList();

            return View(vm);
        }
    }
}