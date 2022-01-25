using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            throw new NotImplementedException();
        }

        public bool AdminCheck(string email)
        {
            var x = _adminDal.Get(y => y.AdminUserName == email);
            if (x==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public Admin GetByUser(Admin admin)
        {
            return _adminDal.Get(x => x.AdminUserName == admin.AdminUserName);
        }

        public string GetByUser(string user)
        {
            
            
                var x = _adminDal.Get(y => y.AdminUserName == user);
            
                string adminRole = x.AdminRole;
                return adminRole;
            
            
            
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public bool LoginCheck(Admin admin)
        {
            var adminuserinfo = _adminDal.Get(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (adminuserinfo !=null)
            {
                return true;
            }
            return false;
        }
    }
}
