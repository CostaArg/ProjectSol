using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMusic.Entities;
using ProjectMusic.Entities.Domain;

namespace ProjectMusic.Web.Models
{
    public class HomeViewModel
    {
        public List<Album> Albums{ get; set; }
        public List<string> GenreNames{ get; set; }
      

    }
}