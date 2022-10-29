using FluentValidation;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.FluentValidations
{
    public class ImageValidator : BaseValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Baslık bos gecilemez");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Baslık ismi 20 karakterden fazla olamaz");
            RuleFor(x => x.Title).MinimumLength(8).WithMessage("Baslık ismi 8 karakterden az olamaz");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Acıklama 20 karakterden az olamaz");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Acıklama 50 karakterden fazla olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Acıklama bos gecilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Gorsel yolu  bos gecilemez");

        }
    }
}
