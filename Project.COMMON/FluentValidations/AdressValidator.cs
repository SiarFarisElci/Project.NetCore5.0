using FluentValidation;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.FluentValidations
{
    public class AdressValidator : BaseValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Bos gecilemez");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Bos gecilemez");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Bos gecilemez");
            RuleFor(x => x.Description4).NotEmpty().WithMessage("Bos gecilemez");
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita bilgisi gecilemez");
            RuleFor(x => x.Description1).MaximumLength(25).WithMessage("Luten 20 karakterden fazal girmeyiniz");
            RuleFor(x => x.Description2).MaximumLength(25).WithMessage("Luten 20 karakterden fazal girmeyiniz");
            RuleFor(x => x.Description3).MaximumLength(25).WithMessage("Luten 20 karakterden fazal girmeyiniz");
            RuleFor(x => x.Description4).MaximumLength(25).WithMessage("Luten 20 karakterden fazal girmeyiniz");
        }
    }
}
