using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(200)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } //ilişkili tablolarda silme işlemi kullanmak yerine aktif pasif yapıcaz

        //ilişki:
        //ben bu sınıfa bağlı olan koleksiyon
        //public ICollection<Heading> Headings { get; set; }//hangi sınıfla ilişki kurucağımı belirkiyorum 
    }
}
