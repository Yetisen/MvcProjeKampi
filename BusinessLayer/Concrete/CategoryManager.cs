using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    //manegerların da interface sonuna servese eklenerekoluşturulacak
    {
        ICategoryDal2 _categoryDal;//ctor ile atama yapıcam  //genericrepository çağırarak oluşturmıycam bağımlılık olmasın diye

        public CategoryManager(ICategoryDal2 categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public void CategorUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);//kontrole ihtiyacım var kuralları belirledim bunu controller da çağırıcam
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);//eşit olup olmadığını burada sorguluyorum
        }


        //GenericRepository<Category> repo = new GenericRepository<Category>();
        ////crud işlemi yada başka işlem için o işleme ait metodlar düzenliycem

        //public List<Category> GetAllBl()
        //{
        //    return repo.List();

        //}

        //public void CategoryAddBl(Category p)
        //{
        //    if (p.CatergoryName == "" || p.CatergoryName.Length <= 3 || p.CatergoryDescription == "" || p.CatergoryName.Length >= 51)//normalde validate kısmı oluşturup orada yazıcam
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //ctrl k d düzenleme
        //ctrl d satırı kopyalama
        //f11 pointte atlama
        //ctrl . seçenekleri açıyor
        public List<Category> GetList()
        {
            return _categoryDal.List();//generic reponun seçenekleri geldi bu yüzden yukarıda _categoryDal değer atama repo ile olabilirdi dedik
        }
    }

        
    }

