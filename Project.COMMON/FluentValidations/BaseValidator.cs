using FluentValidation;
using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.FluentValidations
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : class , IEntity
    {
        public BaseValidator()
        {
          
        }
    }
}
