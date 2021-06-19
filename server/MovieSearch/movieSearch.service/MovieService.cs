using movieSearch.IRepository;
using movieSearch.Model.dto;
using movieSerach.iservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace movieSearch.service
{
    public class MovieService : IMovieService
    {
        IRepository<movie> movieRepository;
        public MovieService(IRepository<movie> movieRepository)
        {
            this.movieRepository = movieRepository;
            this.InitializeMovieData();
        }

        public movieList SearchMovie(string key, string value,string sortClumn)
        {
            movieList _movieList = new movieList();
            if(string.IsNullOrEmpty(sortClumn))
            {
                sortClumn = "imdbRating";
            }
            if(key== "Location")
            {
                _movieList.movies = this.movieRepository.Search(m => m.Location == value,sortClumn,true);
            }
            else if (key == "Title")
            {
                _movieList.movies = this.movieRepository.Search(m => m.Title == value, sortClumn, true);
            }
            else
            {
                _movieList.movies = this.movieRepository.Search(m=>true,sortClumn,true);
            }

            return _movieList;
        }
       
        void InitializeMovieData()
        {
            this.movieRepository.Add(new movie { imdbID = "1", imdbRating = 1, Location = "Bangalore", listingType = "U/A", Language = "Hindi", Title = "m1" });
            this.movieRepository.Add(new movie { imdbID = "4", imdbRating = 7, Location = "Bangalore", listingType = "U/A", Language = "Hindi", Title = "m2" });
            this.movieRepository.Add(new movie { imdbID = "2", imdbRating = 3, Location = "Bangalore", listingType = "U/A", Language = "Hindi", Title = "abc" });
        }
    }
}
