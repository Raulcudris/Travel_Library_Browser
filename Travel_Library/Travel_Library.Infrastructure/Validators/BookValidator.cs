using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.DTOs;

namespace Travel_Library.Infrastructure.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(book => book.Isbn)
                .NotNull()
                .WithMessage("La Isbn no puede ser nulo");

            RuleFor(book => book.Title)
               .NotNull()
               .WithMessage("El Titulo no puede ser nulo");

            RuleFor(book => book.Synopsis)
                .Length(10, 500)
                .WithMessage("La longitud del la Synopsis debe estar entre 10 y 500 caracteres");

            RuleFor(post => post.EditorId)
               .NotNull()
               .WithMessage("El Titulo no puede ser nulo");

        }
    }
}
