using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;
using System.Linq;

namespace RepositoryPatternWithUOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private List<string> AllowedExtentions = new List<string> { ".png", ".jpg" };
        private long AllowedSizeForPoster = 1048576;
        private readonly IUnitOfWork _unitofwork;
        public MoviesController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public IActionResult GetMovies ()
        {
            var movies = _unitofwork.Movies.GetAll( x => x.Rate , x => x.Category);
            return Ok(movies);
        }
        [HttpPost]
        public IActionResult AddMovie([FromForm]MovieDto dto)
        {
            if (!AllowedExtentions.Contains(Path.GetExtension(dto.poster.FileName).ToLower()))
                return BadRequest("Allowed Extentions (jpg , png)");
            
            if (dto.poster.Length > AllowedSizeForPoster)
                return BadRequest("Maximum allowed size is 1 MG");
            
            var isvalid = _unitofwork.Categories.Get(dto.CategoryId);
            
            if(isvalid == null) 
                return BadRequest("Id not exist");

            using var datastream = new MemoryStream();
            dto.poster.CopyTo(datastream);

            var movie = new Movie
            {
                CategoryId = dto.CategoryId,
                Title = dto.Title,
                poster = datastream.ToArray(),
                Rate = dto.Rate,
                Year = dto.Year,
                Storeline = dto.Storeline,
            };
            _unitofwork.Movies.Add(movie);  
            _unitofwork.Complete(); 
            return Ok(movie);
        }
    }
}
