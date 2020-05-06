using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Entities.Domain
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required, MaxLength(60), MinLength(1)]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        public string ArtistPhotoUrl { get; set; }



        //an artist can have many songs
        public virtual ICollection<Song> Songs { get; set; }


        //an artist can have multiple albums
        public virtual ICollection<Album> Albums { get; set; }
    }
}
