using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Storeline { get; set; }
        public int Year { get; set; }
        [MaxLength(250)]
        public required string Title { get; set; }
        public double Rate { get; set; }
        public required byte[] poster { get; set; }
        public int CategoryId { get; set; }
        public  Category? Category { get; set; }
    }
}
