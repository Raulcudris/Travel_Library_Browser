using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.DTOs;

namespace Travel_Library.Infrastructure.Validators
{
    public class Author_has_BookValidator: AbstractValidator<Author_has_BooksDto>
    {
        public Author_has_BookValidator()
        {
            RuleFor(author_book => author_book.AuthorsId)
                .NotNull()
                .WithMessage("La Id del autor no puede ser nulo");

            RuleFor(author_book => author_book.BookIsbn)
                  .NotNull()
                  .WithMessage("La Id del libro no puede ser nulo");

        }
    }
}
