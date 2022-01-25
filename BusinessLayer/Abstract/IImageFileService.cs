using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        //void ImageAdd(ImageFile about);
        //void ImageDelete(ImageFile about);
        //void ImageUpdate(ImageFile about);
        //About GetByID(int id);
    }
}
