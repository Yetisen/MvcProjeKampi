using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHeadingDal : IRepository<Heading>//değer olarak bu sınıfı gönderecek
        //bu sayede hepsine aynı metodları yazmaktan kurtuldum
    {
    }
}
