using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using movieSearch.IRepository;
using movieSearch.Model.dto;
using movieSerach.iservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace movieSearch.service.tes
{
    [TestClass]
    public class MovieServiceTest
    {
        
        Mock<IRepository<movie>> _mockRepository;
        IMovieService movieService;
        [TestInitialize]
        public void Setup()
        {

            movie _movie = new movie { imdbID = "1", imdbRating = 1, Location = "Bangalore", listingType = "U/A", Language = "Hindi", Title = "m1" };

            _mockRepository = new Mock<IRepository<movie>>();
            _mockRepository.Setup(x => x.Search(It.IsAny<Func<movie, bool>>(), It.IsAny<string>(), It.IsAny<bool>())).Returns(new List<movie> { _movie });

            movieService = new MovieService(_mockRepository.Object);
        }

        [TestMethod]
        public void Check_MovieCount()
        {

            var movies = movieService.SearchMovie("Title", "m1", "imdbRating");
            Assert.AreEqual(1, movies.movies.Count);

        }
    }
}
