using ETicaret_API.Application.ViewModels.Products;
using ETicaret_API.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret_API.Application.Validators.FluentValidation.Products
{
    public class CreateProductValidator :AbstractValidator<WM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Product Name Must Be Entered").MaximumLength(150).MinimumLength(1).WithMessage("Product Name leght must be between 2 and 150");
            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Stock Amount must be entered!").Must(s => s >= 0).WithMessage("Stock Amount Must Be Greather Then 0!!");
            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Stock Amount must be entered!").Must(s => s >= 0).WithMessage("Stock Amount Must Be Greather Then 0!!");


        }
    }
}
