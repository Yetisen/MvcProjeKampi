using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class//IRepository den alacaksın
    {
        DbContext _dbContext;
        Context c = new Context();
        DbSet<T> _object;
        //T değerine karşılık gelen sınıfı nereden bulucam ctor
        public GenericRepository()
        {
            _object = c.Set<T>();//context e bağlı olarak gönderilen T olacak
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> Filtre)
        {
            return _object.Where(Filtre).ToList();
        }

        public void Update(T p)
        {
            
            c.SaveChanges();
        }
    }
}
