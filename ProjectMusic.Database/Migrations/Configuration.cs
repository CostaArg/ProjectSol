﻿namespace ProjectMusic.Database.Migrations
{
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

            Album al1 = new Album() { AlbumName = "The Slim Shady LP" };
            Album al2 = new Album() { AlbumName = "Strauss, J.: An der schonen blauen Donau (The Blue Danube)" };
            Album al3 = new Album() { AlbumName = "Fear Inoculum" };
            Album al4 = new Album() { AlbumName = "Combat Rock" };
            Album al5 = new Album() { AlbumName = "Poems, Prayers and Promises" };

            Song s1 = new Song() { SongName = "My Name Is" };
            Song s2 = new Song() { SongName = "An der schonen blauen Donau, Op. 314" };
            Song s3 = new Song() { SongName = "Pneuma" };
            Song s4 = new Song() { SongName = "Should I Stay or Should I Go" };
            Song s5 = new Song() { SongName = "Country Roads" };

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

            //Assigning songs to artists
            ar1.Songs = new List<Song>() { s1 };
            ar2.Songs = new List<Song>() { s2 };
            ar3.Songs = new List<Song>() { s3 };
            ar4.Songs = new List<Song>() { s4 };
            ar5.Songs = new List<Song>() { s5 };

            //Assigning songs to genres
            g1.Songs = new List<Song>() { s1 };
            g2.Songs = new List<Song>() { s2 };
            g3.Songs = new List<Song>() { s3 };
            g4.Songs = new List<Song>() { s4 };
            g5.Songs = new List<Song>() { s5 };

            //Assigning artist to albums
            al1.Artist = ar1;
            al2.Artist = ar2;
            al3.Artist = ar3;
            al4.Artist = ar4;
            al5.Artist = ar5;

            //Assigning songs to albums
            al1.Songs = new List<Song>() { s1 };
            al2.Songs = new List<Song>() { s2 };
            al3.Songs = new List<Song>() { s3 };
            al4.Songs = new List<Song>() { s4 };
            al5.Songs = new List<Song>() { s5 };

            //Upserting

            context.Artists.AddOrUpdate(x => x.ArtistId, ar1, ar2, ar3, ar4, ar5);
            context.Albums.AddOrUpdate(x => x.AlbumId, al1, al2, al3, al4, al5);
            context.Genres.AddOrUpdate(x => x.GenreId, g1, g2, g3, g4, g5);
            context.Songs.AddOrUpdate(x => x.SongId, s1, s2, s3, s4, s5);

            #endregion

            context.SaveChanges();
        }
    }
}
