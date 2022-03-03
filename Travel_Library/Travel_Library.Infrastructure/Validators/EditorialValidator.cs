using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.DTOs;

namespace Travel_Library.Infrastructure.Validators
{
    public class EditorialValidator : AbstractValidator<EditorialDto>
    {
        public EditorialValidator()
        {
            RuleFor(editorial => editorial.Name)
                .NotNull()
                .WithMessage("El Nombre no puede ser nulo");

            RuleFor(editorial => editorial.Campus)
               .NotNull()
               .WithMessage("La Sede no puede ser nulo");
          

        }

    }
}
