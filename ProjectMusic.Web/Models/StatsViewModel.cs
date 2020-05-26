using ProjectMusic.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMusic.Web.Models
{
    public class StatsViewModel
    {
        public List<Album> Albums { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<Order> Orders { get; set; }
    }
}