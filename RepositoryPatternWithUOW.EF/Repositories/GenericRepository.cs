using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public T Add(T item)
        {
           _context.Set<T>().Add(item);
            return item;
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Delete(T item)
        {
            _context.Set<T>().Remove(item);
            return item;
        }

        
    }
}
