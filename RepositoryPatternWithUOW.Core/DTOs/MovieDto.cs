﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class MovieDto
    {
        public string? Storeline { get; set; }
        public int Year { get; set; }
        [MaxLength(250)]
        public string? Title { get; set; }
        public double Rate { get; set; }
        public  IFormFile? poster { get; set; }
        public int CategoryId { get; set; }
    }
}
