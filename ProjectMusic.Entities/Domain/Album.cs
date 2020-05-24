using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Entities.Domain
{
    public class Album
    {
        public int AlbumId { get; set; }
        [Required, MaxLength(60), MinLength(1)]
        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }
        public string AlbumPhotoUrl { get; set; }
        public decimal AlbumPrice { get; set; }
        public int AlbumPurchases { get; set; }


        //multiple albums can belong to one artist
        public virtual Artist Artist { get; set; }


        //multiple albums can have multiple songs
        public virtual ICollection<Song> Songs { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
