
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.core.DTOs;

namespace Tienda.infrec.Validaciones
{
    public class ProductoValidator : AbstractValidator<ProductoDto>
    {
        public ProductoValidator()
        {
            RuleFor(producto => producto.IdProducto)
                .GreaterThan(0)
                .WithMessage("La id producto, no puede ser nula");

            RuleFor(producto =>producto.Nombre)
                .NotNull()
                .Length(1,45)
                .WithMessage("La longitud del nombre no puede ser mayor de 45 caracteres");

            RuleFor(producto => producto.Descripcion)
                .Length(0, 200)
                .WithMessage("La longitud del la descripcion no puede ser mayor de 200 caracteres");
        }
    }
}
