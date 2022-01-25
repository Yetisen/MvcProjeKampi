using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");//şunun için kural
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Soyadını boş geçemezsiniz.");//şunun için kural
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).Must(Control).WithMessage("Hakkında kısmı A harfini içermeli."); //ödev
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");//şunun için kural
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın.");//şunun için kural
        }
       private bool Control(string c)
        {
            if (c.Contains("a"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
