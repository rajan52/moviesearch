using movieSearch.Model.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace movieSerach.iservice
{
    public interface IMovieService
    {
        movieList SearchMovie(string key, string value, string sortClumn);
    }
}
