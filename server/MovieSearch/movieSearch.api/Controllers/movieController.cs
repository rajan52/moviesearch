using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieSearch.Model.dto;
using movieSerach.iservice;

namespace movieSearch.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class movieController : ControllerBase
    {
        IMovieService movieService;
        public movieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET: api/movie
        [HttpGet]
        public movieList Get(string searchKey,string searchValue, string sortColumn )
        {
           return this.movieService.SearchMovie(searchKey,searchValue,sortColumn);
        }

        // GET: api/movie/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/movie
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
