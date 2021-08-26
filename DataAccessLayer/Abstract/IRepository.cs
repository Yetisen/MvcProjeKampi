using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>//veritabanında tabloyu yani entity i göndereceğim
    {
        List<T> List(); //t neyse onu grie
        void Insert(T p); //tablom neyse ondan parametre
        void Update(T p);
        void Delete(T p);

        //yeni 1 öğe ekliycem filtreleme için kullanıcam
        List<T> List(Expression<Func<T,bool>> Filtre); //şartlı listeleme yapacak
    }
}
