using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);//benim gönderdiğim id ye eşit olan
        }

        public Writer GetByUser(Writer writer)
        {
            return _writerDal.Get(x => x.WriterMail == writer.WriterMail);
        }

        public Writer GetByMail(string p)
        {
            return _writerDal.Get(x => x.WriterMail == p);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public bool LoginCheck(Writer writer)
        {
            var writeruserinfo = _writerDal.Get(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (writeruserinfo != null)
            {
                return true;
            }
            return false;
        }

        public void WriterAdd(Writer writer)
        {
             _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
