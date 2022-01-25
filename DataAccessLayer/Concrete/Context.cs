using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context:DbContext
    {
        //Context sınıfı ekledik
        public DbSet<About> Abouts { get; set; }//Abouts sql de veri tabanındaki tablonun ismi oraya yansıycak About sınıfın ismi
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }


        //Bu tabloyu sgl e göndermek için  web config de bağlantı stringi oluşturup view-package manager console kısmına enable-migrations ve ardından true çeküp update-database komutlarını yaptıktan sonra veri tabanı güncellenir.
        /*ayar:
         * <connectionStrings>
    <add name="Context" connectionString="data source=(localdb)\MSSQLLocalDB; initial catalog=DbMvcKamp; integrated security=true;" providerName="System.Data.SqlClient"/>
  </connectionStrings>*/

    }
}
