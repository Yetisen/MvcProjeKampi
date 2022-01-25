using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        //Generic repositorye bağlı olan ICategoryDalım var
        List<Admin> GetList();
        void AdminAdd(Admin admin);
        Admin GetById(int id);//t nin category old idye göre getirmesini söyledik //get by id ile o id nin değerleri gelir
        void AdminDelete(Admin admin);
        //normalde silme işlemini kullanmıycaz ilişkili tablolarda sıkıntı
        void AdminUpdate(Admin admin);
        bool LoginCheck(Admin admin);
        Admin GetByUser(Admin admin);
        string GetByUser(String user);
        bool AdminCheck(string email);

    }
}
