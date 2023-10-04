using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategories Categories { get; private set; }

        public IMovies Movies { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Categories = new CategotyRepository(_context);

            Movies = new MovieRepository(_context);
        }

        public void Dispose()
        {
           _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
