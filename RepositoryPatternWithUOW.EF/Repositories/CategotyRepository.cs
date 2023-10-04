using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class CategotyRepository : GenericRepository<Category>, ICategories
    {
      private readonly ApplicationDbContext _context;

        public CategotyRepository(ApplicationDbContext context) :base(context) 
        {
            
        }
    }
}
