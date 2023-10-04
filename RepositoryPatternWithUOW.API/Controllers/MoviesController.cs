using AutoMapper;
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
        private readonly IMapper _mapper;
        public MoviesController(IUnitOfWork unitofwork , IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;   
        }
        [HttpGet]
        public IActionResult GetMovies()
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

            var movie = _mapper.Map<Movie>(dto);
            movie.poster = datastream.ToArray();

            _unitofwork.Movies.Add(movie);  
            _unitofwork.Complete(); 

            return Ok(movie);
        }
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _unitofwork.Movies.Get(id , x => x.Category );
            return Ok(movie);
        }
    }
}
