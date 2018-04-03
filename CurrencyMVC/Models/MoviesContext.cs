using System;
using System.Collections.Generic;

namespace CurrencyMVC.Models
{
    public class MoviesContext
    {
        private List<MovieModel> movies;
        public List<MovieModel> Movies
        {
            get { return movies; }
            set { movies = value; }
        }

        public MoviesContext()
        {
            movies = new List<MovieModel>();
            GenerateSampleList();
        }

        private void GenerateSampleList()
        {
            movies.Add(new MovieModel("Ted", movies.Count, 2012, "Comedy"));
            movies.Add(new MovieModel("The Dark Knight", movies.Count, 2008, "Thriller"));
            movies.Add(new MovieModel("The Conjuring", movies.Count, 2013, "Horror"));
        }

        public void AddMovie(string Title, int year, string Genre)
        {
            MovieModel movie = new MovieModel(Title, movies.Count, year, Genre);
            if (!Movies.Contains(movie))
            {
                Movies.Add(movie);
            }
        }
        public void RemoveMovie(MovieModel movie)
        {
            try
            {
                movies.Remove(movie);
            }
            catch(Exception ex) { }
        }

        public void EditMovie(MovieModel movie, string Title, int year, string Genre)
        {
            int key = movie.PrimaryKey;

                movie.Title = Title;
                movie.PrimaryKey = key;
                movie.YearReleased = year;
                movie.Genre = Genre;

            movies[key] = movie;
        }
    }
}