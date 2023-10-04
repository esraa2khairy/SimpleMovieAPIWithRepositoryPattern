using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovies
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        IEnumerable<Movie> IMovies.GetAll(Expression<Func<Movie, object>> expression, Expression<Func<Movie, object>> include)
        {
            return _context.movies.OrderByDescending(expression).Include(include).ToList();
        }
    }
}
