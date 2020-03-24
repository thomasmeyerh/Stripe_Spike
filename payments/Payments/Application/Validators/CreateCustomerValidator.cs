using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(customer => customer.Name).NotNull().NotEmpty();
            RuleFor(customer => customer.Email).EmailAddress();
        }
    }
}
