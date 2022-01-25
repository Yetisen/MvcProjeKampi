using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMessageServices
    {
        List<Message> GetListInbox(string p);//gelen
        List<Message> GetListSendbox(string p);//göndrilen
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        
        void MessageUpdate(Message message);
    }
}
