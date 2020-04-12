using ProjectMusic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase db = new MyDatabase();

            var artists = db.Artists.ToList();
            var albums = db.Albums.ToList();
            var songs = db.Songs.ToList();
            var genres = db.Genres.ToList();

            #region PRINTING DATA

            //artists

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("ARTISTS");
            Console.WriteLine();

            foreach (var artist in artists)
            {
                Console.WriteLine(artist.ArtistId + ". Artist Name: " + artist.ArtistName);
            }

            //albums

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("ALBUMS");
            Console.WriteLine();

            foreach (var album in albums)
            {
                Console.WriteLine(album.AlbumId + ". Album Name: " + album.AlbumName);
            }

            //songs

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("SONGS");
            Console.WriteLine();

            foreach (var song in songs)
            {
                Console.WriteLine(song.SongId + ". Song Name: " + song.SongName);
            }

            //genres

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("GENRES");
            Console.WriteLine();

            foreach (var genre in genres)
            {
                Console.WriteLine(genre.GenreId + ". Genre: " + genre.GenreName);
            }

            //albums per artist

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("ALBUMS PER ARTIST");
            Console.WriteLine();

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist Name: " + artist.ArtistName);
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine("Album Name: " + album.AlbumName);
                }
            }

            //songs per artist

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("SONGS PER ARTIST");
            Console.WriteLine();

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist Name: " + artist.ArtistName);

                foreach (var song in artist.Songs)
                {
                    Console.WriteLine("Song Name: " + song.SongName);
                }
            }

            //songs per album
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("SONGS PER ALBUM");
            Console.WriteLine();

            foreach (var album in albums)
            {
                Console.WriteLine("Album Name: " + album.AlbumName);

                foreach (var song in album.Songs)
                {
                    Console.WriteLine("Song Name: " + song.SongName);
                }
            }

            //artist's album
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("ARTIST\'S ALBUM");
            Console.WriteLine();

            foreach (var artist in artists)
            {
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine("Album Name: " + album.AlbumName);
                }
            }

            //songs per genre
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("SONGS PER GENRE");
            Console.WriteLine();

            foreach (var genre in genres)
            {
                Console.WriteLine("Genre: " + genre.GenreName);

                foreach (var song in genre.Songs)
                {
                    Console.WriteLine("Song Name: " + song.SongName);
                }
            }

            //genres per song
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("GENRES PER SONG");
            Console.WriteLine();

            foreach (var song in songs)
            {
                foreach (var genre in song.Genres)
                {
                    Console.WriteLine("Genres: " + genre.GenreName);
                }
            }

            //albums per song
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("ALBUMS PER SONG");
            Console.WriteLine();

            foreach (var song in songs)
            {
                foreach (var album in song.Albums)
                {
                    Console.WriteLine("Album Name: " + album.AlbumName);
                }
            }

            //artists per song
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("ARTISTS PER SONG");
            Console.WriteLine();

            foreach (var song in songs)
            {
                foreach (var artist in song.Artists)
                {
                    Console.WriteLine("Artist Name: " + artist.ArtistName);
                }
            }

            //song per album per artist
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("SONG PER ALBUM PER ARTIST");
            Console.WriteLine();

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist Name: " + artist.ArtistName);
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine("Album Name: " + album.AlbumName);

                    foreach (var song in album.Songs)
                    {
                        Console.WriteLine("Song Name: " + song.SongName);
                    }
                }
            }

            #endregion

        }
    }
}
