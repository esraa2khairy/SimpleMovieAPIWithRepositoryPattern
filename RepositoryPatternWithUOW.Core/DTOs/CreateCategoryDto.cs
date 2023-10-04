using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class CreateCategoryDto
    {
        [MaxLength(100)]
        public required String Name { get; set; }
    }
}
