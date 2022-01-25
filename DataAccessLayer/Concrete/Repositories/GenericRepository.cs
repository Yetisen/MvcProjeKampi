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
            var deletedEntity = c.Entry(p);//silinecek olan parametreden gelen değerdir
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)//silme işlemi için önce bulduruyoruz
        {//id si 5 olan değer dediğim için tek değer döner
            return _object.SingleOrDefault(filter);//bir dizide yada listede sadece 1 değer döndürmek için kul metod
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);//güncelleme sırasında veri tabanına kaydolmuyordu onu çözeceğiz
            addedEntity.State = EntityState.Added;

           // _object.Add(p); //buna gerek kalmadı
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
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
