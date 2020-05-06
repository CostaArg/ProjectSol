using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Entities.Domain
{
    public class Song
    {
        public int SongId { get; set; }
        [Required, MaxLength(60), MinLength(1)]
        [Display(Name = "Song Name")]
        public string SongName { get; set; }


        //a song can belong in many albums
        public virtual ICollection<Album> Albums { get; set; }


        //a song can belong to many artists
        public virtual ICollection<Artist> Artists { get; set; }


        //a song can have multiple genres
        public virtual ICollection<Genre> Genres{ get; set; }
    }
}
