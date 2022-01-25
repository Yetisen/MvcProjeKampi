using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByHeadingID(int id);//id ile liste getirme
        List<Content> GetListByWriter(int id);
        void ContentgAdd(Content content);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        Content GetByID(int id);
    }
}
