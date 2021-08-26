using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();
        //crud işlemi yada başka işlem için o işleme ait metodlar düzenliycem

        public List<Category> GetAll()
        {
            return repo.List();

        }

        public void CategoryAddBl(Category p)
        {
            if (p.CatergoryName == "" || p.CatergoryName.Length <= 3 || p.CatergoryDescription == "" || p.CatergoryName.Length >= 51)//normalde validate kısmı oluşturup orada yazıcam
            {
                //hata mesajı
            }
            else
            {
                repo.Update(p);
            }
        }
    }
}
