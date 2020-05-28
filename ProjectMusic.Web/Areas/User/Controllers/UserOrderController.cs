using ProjectMusic.Database;
using ProjectMusic.Entities;
using ProjectMusic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMusic.Web.Areas.User.Controllers
{
    public class UserOrderController : Controller
    {
        private IUnitOfWork UnitOfWork = new UnitOfWork(new ApplicationDbContext());

        public ActionResult Index()
        {
            var orders = UnitOfWork.Orders.GetAll();

            return View(orders);
        }
    }
}