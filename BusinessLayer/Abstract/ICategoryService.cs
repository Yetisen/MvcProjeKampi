using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        //Generic repositorye bağlı olan ICategoryDalım var
        List<Category> GetList();
        void CategoryAdd(Category category);
        Category GetById(int id);//t nin category old idye göre getirmesini söyledik //get by id ile o id nin değerleri gelir
        void CategoryDelete(Category category);
        //normalde silme işlemini kullanmıycaz ilişkili tablolarda sıkıntı
        void CategorUpdate(Category category);
        
        
    }
}
