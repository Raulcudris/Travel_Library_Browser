using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.DTOs;

namespace Travel_Library.Infrastructure.Validators
{
   public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.Name)
                .NotNull()
                .WithMessage("El Nombre no puede ser nulo");

            RuleFor(author => author.LastName)
                .NotNull()
                .WithMessage("El Apellido no puede ser nulo");

        }
    }
}
