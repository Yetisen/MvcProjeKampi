using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    interface ICategoryDal
    {
        //Dry araştır.
        //böyle tek tek yapamam çok fazla sınıfım olabilir ayrı ca hepsi için tek tek (Category)Repository yazmam gerekir.
        List<Category> List();
        void Insert(Category p);
        void Update(Category p);
        void Delete(Category p);
    }
}
