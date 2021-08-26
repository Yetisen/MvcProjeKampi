using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        //somut sınıflarım
        //bu sıtıfa ait property lerim olacak //başlık tablosu
        [Key]
        public int HeadingID { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        //yazar

        public int CategoryID { get; set; }
        public virtual  Category  Category { get; set; }
        public int WriterID { get; set; }//başlığı açan kişinin ID sini görmeliyim
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
