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
        //27.video
        List<T> List(); //t neyse onu grie
        void Insert(T p); //tablom neyse ondan parametre
        T Get(Expression<Func<T, bool>> filter);
        void Update(T p);
        void Delete(T p);

        //yeni 1 öğe ekliycem filtreleme için kullanıcam
        List<T> List(Expression<Func<T,bool>> filter); //şartlı listeleme yapacak
        //bunların içini Generic repositoryde doldurduk hepsi birbirine bağlı
        //böylelikle Generic repositoryi newlemeden içindeki değerlere ulaşabiliyorum
    }
}
