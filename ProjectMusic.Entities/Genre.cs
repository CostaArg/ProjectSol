using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required, MaxLength(60), MinLength(1)]
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
        public string GenrePhotoUrl { get; set; }


        //many genres can label many songs
        public virtual ICollection<Song> Songs { get; set; }
    }
}
