using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IMovies : IGenericRepository<Movie>
    {
       IEnumerable<Movie> GetAll(Expression<Func<Movie, object>> expression, Expression<Func<Movie, object>> include);
       Movie Get(int id , Expression<Func<Movie, object>> include);
       void Update(Movie item);
    }
}
