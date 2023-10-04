using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF;

namespace RepositoryPatternWithUOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategotiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public CategotiesController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok( _unitofwork.Categories.GetAll().OrderBy(x => x.Name));
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryDto dto)
        {
            var categoty = new Category { Name = dto.Name };
            _unitofwork.Categories.Add(categoty);
           _unitofwork.Complete();
            return Ok(categoty);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateCategoryDto dto)
        {
            var categoty = _unitofwork.Categories.Get(id);

            if (categoty == null) return NotFound($"Category with id {id} not found");

            categoty.Name = dto.Name;

            _unitofwork.Complete();

            return Ok(categoty);
        }

        [HttpDelete("{id}")]
        public  ActionResult Delete(int id)
        {
            var category =  _unitofwork.Categories.Get(id);
           
            if (category == null) return NotFound($"Category with id {id} not found");

            _unitofwork.Categories.Delete(category);

            _unitofwork.Complete();
            
            return Ok(category);
        }
    }
}
