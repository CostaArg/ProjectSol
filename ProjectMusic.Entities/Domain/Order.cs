using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Entities.Domain
{
    public class Order
    {
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }

        public virtual ApplicationUser User { get; set; } 

        public virtual Album Album { get; set; }

        public virtual DateTime DatePurchased { get; set; }

        //[Key, Column(Order = 2)]
        //public string UserId { get; set; }

        //[Key, Column(Order = 3)]
        //public int AlbumId { get; set; }
    }
}
