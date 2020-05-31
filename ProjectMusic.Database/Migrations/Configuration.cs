namespace ProjectMusic.Database.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProjectMusic.Entities;
    using ProjectMusic.Entities.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectMusic.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjectMusic.Database.ApplicationDbContext context)
        {
            #region SEEDING DATA

            Artist ar1 = new Artist() { ArtistName = "Eminem" };
            Artist ar2 = new Artist() { ArtistName = "Johann Strauss II" };
            Artist ar3 = new Artist() { ArtistName = "TOOL" };
            Artist ar4 = new Artist() { ArtistName = "The Clash" };
            Artist ar5 = new Artist() { ArtistName = "John Denver" };
            Artist ar6 = new Artist() { ArtistName = "Queen" };
            Artist ar7 = new Artist() { ArtistName = "Scorpions" };
            Artist ar8 = new Artist() { ArtistName = "Mobb Deep" };
            Artist ar9 = new Artist() { ArtistName = "Johnny Cash" };
            Artist ar10 = new Artist() { ArtistName = "Metallica" };

            Album al1 = new Album() { AlbumName = "The Slim Shady LP", AlbumPrice = 19.99M, AlbumPurchases = 15 };
            Album al2 = new Album() { AlbumName = "Strauss, J. An der schonen blauen Donau (The Blue Danube)", AlbumPrice = 24.99M, AlbumPurchases = 34 };
            Album al3 = new Album() { AlbumName = "Fear Inoculum", AlbumPrice = 14.89M, AlbumPurchases = 7 };
            Album al4 = new Album() { AlbumName = "Combat Rock", AlbumPrice = 27.99M, AlbumPurchases = 36 };
            Album al5 = new Album() { AlbumName = "Poems, Prayers and Promises", AlbumPrice = 11.95M, AlbumPurchases = 21 };
            Album al6 = new Album() { AlbumName = "Hot Space", AlbumPrice = 22.99M, AlbumPurchases = 11 };
            Album al7 = new Album() { AlbumName = "Return to Forever", AlbumPrice = 6.99M, AlbumPurchases = 26 };
            Album al8 = new Album() { AlbumName = "The Infamous", AlbumPrice = 36.99M, AlbumPurchases = 19 };
            Album al9 = new Album() { AlbumName = "American IV The Man Comes Around", AlbumPrice = 52.99M, AlbumPurchases = 12 };
            Album al10 = new Album() { AlbumName = "Ride The Lightning", AlbumPrice = 12.95M, AlbumPurchases = 3 };

            Song s1 = new Song() { SongName = "My Name Is" };
            Song s2 = new Song() { SongName = "An der schonen blauen Donau, Op. 314" };
            Song s3 = new Song() { SongName = "Pneuma" };
            Song s4 = new Song() { SongName = "Should I Stay or Should I Go" };
            Song s5 = new Song() { SongName = "Country Roads" };
            Song s6 = new Song() { SongName = "Under Pressure" };
            Song s7 = new Song() { SongName = "All for One" };
            Song s8 = new Song() { SongName = "Trife Life" };
            Song s9 = new Song() { SongName = "Hurt" };
            Song s10 = new Song() { SongName = "For Whom The Bell Tolls" };

            Genre g1 = new Genre() { GenreName = "Rap" };
            Genre g2 = new Genre() { GenreName = "Classical" };
            Genre g3 = new Genre() { GenreName = "Metal" };
            Genre g4 = new Genre() { GenreName = "Rock" };
            Genre g5 = new Genre() { GenreName = "Country" };

            //Assigning albums to artists
            ar1.Albums = new List<Album>() { al1 };
            ar2.Albums = new List<Album>() { al2 };
            ar3.Albums = new List<Album>() { al3 };
            ar4.Albums = new List<Album>() { al4 };
            ar5.Albums = new List<Album>() { al5 };
            ar6.Albums = new List<Album>() { al6 };
            ar7.Albums = new List<Album>() { al7 };
            ar8.Albums = new List<Album>() { al8 };
            ar9.Albums = new List<Album>() { al9 };
            ar10.Albums = new List<Album>() { al10 };

            //Assigning songs to artists
            ar1.Songs = new List<Song>() { s1 };
            ar2.Songs = new List<Song>() { s2 };
            ar3.Songs = new List<Song>() { s3 };
            ar4.Songs = new List<Song>() { s4 };
            ar5.Songs = new List<Song>() { s5 };
            ar6.Songs = new List<Song>() { s6 };
            ar7.Songs = new List<Song>() { s7 };
            ar8.Songs = new List<Song>() { s8 };
            ar9.Songs = new List<Song>() { s9 };
            ar10.Songs = new List<Song>() { s10 };

            //Assigning songs to genres
            g1.Songs = new List<Song>() { s1, s8 };
            g2.Songs = new List<Song>() { s2 };
            g3.Songs = new List<Song>() { s3, s10 };
            g4.Songs = new List<Song>() { s4, s6, s7 };
            g5.Songs = new List<Song>() { s5, s9 };

            //Assigning artist to albums
            al1.Artist = ar1;
            al2.Artist = ar2;
            al3.Artist = ar3;
            al4.Artist = ar4;
            al5.Artist = ar5;
            al6.Artist = ar6;
            al7.Artist = ar7;
            al8.Artist = ar8;
            al9.Artist = ar9;
            al10.Artist = ar10;

            //Assigning songs to albums
            al1.Songs = new List<Song>() { s1 };
            al2.Songs = new List<Song>() { s2 };
            al3.Songs = new List<Song>() { s3 };
            al4.Songs = new List<Song>() { s4 };
            al5.Songs = new List<Song>() { s5 };
            al6.Songs = new List<Song>() { s6 };
            al7.Songs = new List<Song>() { s7 };
            al8.Songs = new List<Song>() { s8 };
            al9.Songs = new List<Song>() { s9 };
            al10.Songs = new List<Song>() { s10 };

            //Accounts
            string adminEmail = "admin@yahoo.com";
            string adminPass = "admin123";

            string user1Email = "dimitris@gmail.com";
            string user1Pass = "dokimi123";

            string user2Email = "giorgos@hotmail.com";
            string user2Pass = "test123";

            if (!context.Users.Any(user => user.UserName == adminEmail))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var adminAccount = new ApplicationUser { UserName = adminEmail, Email = adminEmail };

                manager.Create(adminAccount, adminPass);

                Order firstOrder = new Order() { User = adminAccount, Album = al1, DatePurchased = DateTime.Now };

                context.Orders.AddOrUpdate(x => x.OrderId, firstOrder);
            }

            if (!context.Users.Any(user => user.UserName == user1Email))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user1Account = new ApplicationUser { UserName = user1Email, Email = user1Email };

                manager.Create(user1Account, user1Pass);

                Order firstOrder = new Order() { User = user1Account, Album = al1, DatePurchased = DateTime.Now };
                Order secondOrder = new Order() { User = user1Account, Album = al3, DatePurchased = DateTime.Now };
                Order thirdOrder = new Order() { User = user1Account, Album = al2, DatePurchased = DateTime.Now };

                context.Orders.AddOrUpdate(x => x.OrderId, firstOrder, secondOrder, thirdOrder);
            }

            if (!context.Users.Any(user => user.UserName == user2Email))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user2Account = new ApplicationUser { UserName = user2Email, Email = user2Email };

                manager.Create(user2Account, user2Pass);

                Order firstOrder = new Order() { User = user2Account, Album = al2, DatePurchased = DateTime.Now };
                Order secondOrder = new Order() { User = user2Account, Album = al1, DatePurchased = DateTime.Now };

                context.Orders.AddOrUpdate(x => x.OrderId, firstOrder, secondOrder);
            }

            //Upserting

            context.Artists.AddOrUpdate(x => x.ArtistId, ar1, ar2, ar3, ar4, ar5, ar6, ar7, ar8, ar9, ar10);
            context.Albums.AddOrUpdate(x => x.AlbumId, al1, al2, al3, al4, al5, al6, al7, al8, al9, al10);
            context.Genres.AddOrUpdate(x => x.GenreId, g1, g2, g3, g4, g5);
            context.Songs.AddOrUpdate(x => x.SongId, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10);

            #endregion

            context.SaveChanges();
        }
    }
}
