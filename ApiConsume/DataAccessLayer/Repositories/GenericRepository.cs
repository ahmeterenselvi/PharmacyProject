using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly RepositoryContext _context;
        public GenericRepository(RepositoryContext context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
            return t;
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}
