using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public  string? Storeline { get; set; }
        public int Year { get; set; }
        public string? Title { get; set; }
        public double Rate { get; set; }
        public byte[]? poster { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName  { get; set; }
    }
}
