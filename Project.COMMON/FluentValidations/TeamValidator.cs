using FluentValidation;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.FluentValidations
{
    public class TeamValidator : BaseValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı bos gecilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title alanı bos gecilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name alanı icin 50 karakterden az giriş yapın");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name alanı icin 2 karakterden az giriş yapın");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName alanı bos gecilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu alanı bos gecilemez");
        }
    }
}
